using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MyShop.Domain.Storage;
using MyShop.Events;
using MyShop.EventStorage.Properties;

namespace MyShop.EventStorage
{
    /// <summary>
    /// Stores events for a SQL database and publish them via a bus.
    /// </summary>
    public class SqlEventStore : IEventStore
    {
        #region Queries
        private const String DeleteUnusedProviders =
            @"DELETE FROM [EventProviders] WHERE (SELECT Count(EventProviderId) FROM [Events] WHERE [EventProviderId]=[EventProviders].[Id]) = 0";

        private const String InsertNewEventQuery =
            @"INSERT INTO [Events]([EventProviderId], [Name], [Data], [TimeStamp]) VALUES (@Id, @Name, @Data, getDate())";

        private const String InsertNewProviderQuery =
            @"INSERT INTO [EventProviders](Id, Type, Version) VALUES (@Id, @Type, @Version)";

        private const String SelectAllEventsQuery =
            @"SELECT [TimeStamp], [Data] FROM [Events] WHERE [EventProviderId] = @EventProviderId ORDER BY [TimeStamp]";

        private const String SelectAllIdsForTypeQuery = @"SELECT [Id] FROM [EventProviders] WHERE [Type] = @Type";

        private const String SelectVersionQuery = @"SELECT [Version] FROM [EventProviders] WHERE [Id] = @id";

        private const String UpdateEventProviderVersionQuery =
            @"UPDATE [EventProviders] SET [Version] = (SELECT Count(*) FROM [Events] WHERE [EventProviderId] = @Id) WHERE [Id] = @id";
        #endregion

        #region IEventStore Members
        /// <summary>
        /// Gets the SQL server connection string for the MyShopEvents database.
        /// </summary>
        /// <value>The SQL server connection string.</value>
        private static String ConnectionString
        {
            get
            {
                return Settings.Default.MyShopEventsConnectionString;
            }
        }
        #endregion

        /// <summary>
        /// Get all event for a specific event provider.
        /// </summary>
        /// <param name="id">The id of the event provider.</param>
        /// <returns>All events for the specified event provider.</returns>
        public IEnumerable<HistoricalEvent> GetAllEventsForEventProvider(Guid id)
        {
            // Create connection and command.
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(SelectAllEventsQuery, connection))
            {
                // Add EventProviderId parameter and open connection.
                command.Parameters.AddWithValue("EventProviderId", id);
                connection.Open();

                // Execute query and create reader.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Create formatter that can deserialize our events.
                    var formatter = new BinaryFormatter();

                    while (reader.Read())
                    {
                        // Get event details.
                        var timeStamp = (DateTime) reader["TimeStamp"];
                        var rawData = (Byte[]) reader["Data"];

                        using (var dataStream = new MemoryStream(rawData))
                        {
                            // Deserialize event and yield it.
                            var evnt = (IEvent) formatter.Deserialize(dataStream);
                            yield return new HistoricalEvent(timeStamp, evnt);
                        }
                    }

                    // Break the yield.
                    yield break;
                }
            }
        }

        /// <summary>
        /// Saves all events from an event provider.
        /// </summary>
        /// <param name="provider">The event provider.</param>
        /// <returns>The events that are saved.</returns>
        public IEnumerable<IEvent> Save(IEventProvider provider)
        {
            // Get all events.
            IEnumerable<IEvent> events = provider.GetChanges();

            // Create new connection.
            using (var connection = new SqlConnection(ConnectionString))
            {
                // Open connection and begin a transaction so we can
                // commit or rollback all the changes that has been made.
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Get the current version of the event provider.
                    int? currentVersion = GetVersion(provider.Id, transaction);

                    // Create new event provider when it is not found.
                    if (currentVersion == null)
                    {
                        CreateEventProvider(provider, transaction);
                    }
                    else if (currentVersion.Value != provider.Version)
                    {
                        throw new ConcurrencyException(provider.Version, currentVersion.Value);
                    }

                    // Save all events to the store.
                    SaveEvents(events, provider.Id, transaction);

                    // Update the version of the provider.
                    UpdateEventProviderVersion(provider, transaction);

                    // Everything is handled, commint transaction.
                    transaction.Commit();
                }
                catch
                {
                    // Something went wrong, rollback transaction.
                    transaction.Rollback();
                    throw;
                }
            }

            return events;
        }

        public IEnumerable<Guid> GetAllIdsForType(Type eventProviderType)
        {
            // Create connection and command.
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(SelectAllIdsForTypeQuery, connection))
            {
                // Add EventProviderId parameter and open connection.
                command.Parameters.AddWithValue("Type", eventProviderType.FullName);
                connection.Open();

                // Execute query and create reader.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return (Guid) reader[0];
                    }
                }
            }
        }

        public void RemoveUnusedProviders()
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(DeleteUnusedProviders, connection))
            {
                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private static void UpdateEventProviderVersion(IEventProvider provider, SqlTransaction transaction)
        {
            using (var command = new SqlCommand(UpdateEventProviderVersionQuery, transaction.Connection))
            {
                command.Transaction = transaction;
                command.Parameters.AddWithValue("Id", provider.Id);
                command.ExecuteNonQuery();
            }
        }

        private static void SaveEvents(IEnumerable<IEvent> evnts, Guid providerId, SqlTransaction transaction)
        {
            foreach (IEvent evnt in evnts)
            {
                SaveEvent(evnt, providerId, transaction);
            }
        }

        private static void SaveEvent(IEvent evnt, Guid providerId, SqlTransaction transaction)
        {
            var dataStream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(dataStream, evnt);
            byte[] data = dataStream.ToArray();

            using (var command = new SqlCommand(InsertNewEventQuery, transaction.Connection))
            {
                command.Transaction = transaction;
                command.Parameters.AddWithValue("Id", providerId);
                command.Parameters.AddWithValue("Name", evnt.GetType().FullName);
                command.Parameters.AddWithValue("Data", data);
                command.ExecuteNonQuery();
            }
        }

        private static void CreateEventProvider(IEventProvider provider, SqlTransaction transaction)
        {
            using (var command = new SqlCommand(InsertNewProviderQuery, transaction.Connection))
            {
                command.Transaction = transaction;
                command.Parameters.AddWithValue("Id", provider.Id);
                command.Parameters.AddWithValue("Type", provider.GetType().ToString());
                command.Parameters.AddWithValue("Version", provider.Version);
                command.ExecuteNonQuery();
            }
        }

        private static int? GetVersion(Guid providerId, SqlTransaction transaction)
        {
            using (var command = new SqlCommand(SelectVersionQuery, transaction.Connection))
            {
                command.Transaction = transaction;
                command.Parameters.AddWithValue("id", providerId);
                return (int?) command.ExecuteScalar();
            }
        }
    }
}