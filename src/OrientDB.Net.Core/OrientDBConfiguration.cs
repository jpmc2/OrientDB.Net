using OrientDB.Net.Core.Abstractions;
using OrientDB.Net.Core.Configuration;
using System;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace OrientDB.Net.Core
{
    /// <summary>
    /// Represents the configuration for OrientDB.
    /// </summary>
    public class OrientDBConfiguration
    {
        /// <summary>
        /// Connects to OrientDB with the specified result type.
        /// </summary>
        /// <typeparam name="TResultType">The result type of the connection.</typeparam>
        /// <returns>An instance of <see cref="OrientDBConnectionConfiguration{TResultType}"/>.</returns>
        public OrientDBConnectionConfiguration<TResultType> ConnectWith<TResultType>()
        {
            _connectionType = typeof(TResultType);
            return new OrientDBConnectionConfiguration<TResultType>(this, (s) =>
            {
                if (s == null)
                    throw new ArgumentNullException($"{nameof(s)} cannot be null.");
                _serializer = s;
            }, (ca) =>
            {
                if (ca == null)
                    throw new ArgumentNullException($"{nameof(ca)} cannot be null.");
                _connectionProtocol = ca;
            });
        }

        /// <summary>
        /// Gets the logging configuration for OrientDB.
        /// </summary>
        public OrientDBLoggingConfiguration LogWith { get; }

        private object _serializer;
        private object _connectionProtocol;
        private ILogger _logger;
        private Type _connectionType;

        private IOrientDatabaseConnection _orientConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrientDBConfiguration"/> class.
        /// </summary>
        public OrientDBConfiguration()
        {
            LogWith = new OrientDBLoggingConfiguration(this, (l) =>
            {
                if (l == null)
                    throw new ArgumentNullException($"{nameof(l)} cannot be null.");
                _logger = l;
            });
        }

        /// <summary>
        /// Creates a factory for creating OrientDB connections.
        /// </summary>
        /// <returns>An instance of <see cref="IOrientConnectionFactory"/>.</returns>
        /// <exception cref="NullReferenceException">Thrown when the connection protocol, serializer, or logger is null.</exception>
        public IOrientConnectionFactory CreateFactory()
        {
            if (_connectionProtocol == null)
                throw new NullReferenceException($"{_connectionProtocol} cannot be null.");
            if (_serializer == null)
                throw new NullReferenceException($"{_serializer} cannot be null.");
            if (_logger == null)
                throw new NullReferenceException($"{_logger} cannot be null.");

            var factoryType = typeof(OrientConnectionFactory<>).MakeGenericType(_connectionType);

            ConstructorInfo info = factoryType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];

            return (IOrientConnectionFactory)info.Invoke(new object[] { _connectionProtocol, _serializer, _logger });
        }
    }
}
