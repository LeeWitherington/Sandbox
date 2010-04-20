using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.NetworkInformation;



namespace Samples.Services.FinanceInfo
{
    public class FinanceInfoService : IFinanceInfoService
    {

        /// <summary>
        /// No special initialization is required here
        /// </summary>
        public FinanceInfoService()
        {
        }


        #region IFinanceInfoService (as data)

        /// <summary>
        /// Get quotes for the specified list of symbols 
        /// </summary>
        /// <param name="symbols">Comma-separated list of stock symbols to retrieve</param>
        /// <param name="isOffline">Indicates whether offline or live data should be retrieved</param>
        /// <returns>Array of StockInfo</returns>
        public StockInfo[] GetQuotes(string symbols, bool isOffline)
        {
            IFinanceInfoProvider provider = ResolveProvider(isOffline);
            if (provider == null)
                throw new NullReferenceException("Invalid Provider specified.");

            return provider.GetQuotes(symbols);
        }

        /// <summary>
        /// Get quotes for the specified list of symbols 
        /// </summary>
        /// <param name="symbols">Comma-separated list of stock symbols to retrieve</param>
        /// <returns>Array of StockInfo</returns>
        public StockInfo[] GetQuotes(string symbols)
        {
            return GetQuotes(symbols, true);
        }

        /// <summary>
        /// Get quotes for the list of symbols stored in the web.config file of the host 
        /// </summary>
        /// <param name="isOffline">Indicates whether offline or live data should be retrieved</param>
        /// <returns>Array of StockInfo</returns>
        public StockInfo[] GetQuotes(bool isOffline)
        {
            string entry = (isOffline ? FinanceInfoUtils.CONFIG_OFFLINESTOCKSYMBOLS
                                      : FinanceInfoUtils.CONFIG_ONLINESTOCKSYMBOLS);
            string symbols = ConfigurationManager.AppSettings[entry];
            return GetQuotes(symbols, isOffline);
        }

        /// <summary>
        /// Get quotes for the list of symbols stored in the web.config file of the host 
        /// </summary>
        /// <returns>Array of StockInfo</returns>
        public StockInfo[] GetQuotes()
        {
            string symbols = ConfigurationManager.AppSettings[FinanceInfoUtils.CONFIG_OFFLINESTOCKSYMBOLS];
            return GetQuotes(symbols);
        }
        #endregion


        #region IFinanceInfoService (as HTML)

        /// <summary>
        /// Get quotes for the specified list of symbols and returns HTML
        /// </summary>
        /// <param name="symbols">Comma-separated list of stock symbols to retrieve</param>
        /// <param name="isOffline">Indicates whether offline or live data should be retrieved</param>
        /// <returns>HTML message with current quotes</returns>
        public string GetQuotesAsHtml(string symbols, bool isOffline)
        {
            IFinanceInfoProvider provider = ResolveProvider(isOffline);
            if (provider == null)
                throw new NullReferenceException("Invalid Provider specified.");

            return provider.GetQuotesAsHtml(symbols);
        }

        /// <summary>
        /// Get quotes for the list of symbols stored in the web.config file of the host and returns HTML
        /// </summary>
        /// <param name="isOffline">Indicates whether offline or live data should be retrieved</param>
        /// <returns>HTML message with current quotes</returns>
        public string GetQuotesAsHtml(bool isOffline)
        {
            string entry = (isOffline ?FinanceInfoUtils.CONFIG_OFFLINESTOCKSYMBOLS 
                                      :FinanceInfoUtils.CONFIG_ONLINESTOCKSYMBOLS);
            string symbols = ConfigurationManager.AppSettings[entry];
            return GetQuotesAsHtml(symbols, isOffline);
        }

        /// <summary>
        /// Accepts a boolean parameter expressed as a string. Designed for being used with DynamicPopulate
        /// </summary>
        /// <param name="contextKey">The string FALSE if you want live data; everything else for offline data</param>
        /// <returns>HTML message with current quotes</returns>
        public string GetQuotesAsHtml(string contextKey)
        {
            // Parameter is transformed into a Boolean (if possible).
            // The string indicates the value for "isOffline" but has to default to TRUE.
            // If parsing fails, instead, the value is FALSE.
            bool isOffline = true;
            if (String.Equals(contextKey, "false", StringComparison.OrdinalIgnoreCase))
            {
                isOffline = false;
            }

            string entry = (isOffline ? FinanceInfoUtils.CONFIG_OFFLINESTOCKSYMBOLS
                                      : FinanceInfoUtils.CONFIG_ONLINESTOCKSYMBOLS);
            string symbols = ConfigurationManager.AppSettings[entry];
            return GetQuotesAsHtml(symbols, isOffline);
        }

        #endregion

        
        #region Helpers:: Resolvers

        /// <summary>
        /// Returns an instance of the class that provides data to the service
        /// </summary>
        /// <param name="isOffline">Indicates whether offline or live data should be retrieved</param>
        /// <returns>Instance of a class that implements IFinanceInfoProvider</returns>
        protected virtual IFinanceInfoProvider ResolveProvider(bool isOffline)
        {
            IFinanceInfoProvider provider = null;

            if (!isOffline && this.IsConnectedToInternet())
                provider = new OnlineServiceProvider();
            else
                provider = new OfflineServiceProvider();

            return provider;
        }


        /// <summary>
        /// Ping a host and determine whether or not there is Internet connectivity
        /// </summary>
        /// <returns>Boolean</returns>
        private bool IsConnectedToInternet()
        {
            bool result = false;
            Ping p = new Ping();
            PingReply reply = p.Send("www.google.com", 3000);
            if (reply.Status == IPStatus.Success)
                return true;
            
            return result;
        }

        #endregion
    }
}


   