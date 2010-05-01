﻿using System;
using System.Runtime.Serialization;
using MyShop.Commands;

namespace MyShop.CommandHandlers.AutoMapping
{
    /// <summary>
    /// Occurs when there is no auto mapping found for a <see cref="ICommand"/>.
    /// </summary>
    [Serializable]
    public class MappingForCommandNotFoundException : AutoMappingException
    {
        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <value>The command.</value>
        public ICommand Command
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingForCommandNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="command">The command.</param>
        public MappingForCommandNotFoundException(string message, ICommand command)
            : base(message)
        {
            Command = command;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingForCommandNotFoundException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown. </param><param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination. </param><exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception><exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected MappingForCommandNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
