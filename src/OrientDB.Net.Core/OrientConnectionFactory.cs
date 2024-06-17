using OrientDB.Net.Core.Abstractions;
using System;
using Microsoft.Extensions.Logging;

namespace OrientDB.Net.Core
{
    /// <summary>
    /// Represents a factory for creating OrientDB server connections.
    /// </summary>
    /// <typeparam name="TDataType">The type of data used by the connection.</typeparam>
    internal class OrientConnectionFactory<TDataType> : IOrientConnectionFactory
    {
        private readonly IOrientDBConnectionProtocol<TDataType> _connectionProtocol;
        private readonly IOrientDBRecordSerializer<TDataType> _serializer;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrientConnectionFactory{TDataType}"/> class.
        /// </summary>
        /// <param name="connectionProtocol">The connection protocol to be used.</param>
        /// <param name="serializer">The serializer to be used.</param>
        /// <param name="logger">The logger to be used.</param>
        internal OrientConnectionFactory(
            IOrientDBConnectionProtocol<TDataType> connectionProtocol,
            IOrientDBRecordSerializer<TDataType> serializer,
            ILogger logger)
        {
            _connectionProtocol = connectionProtocol ?? throw new ArgumentNullException($"{nameof(connectionProtocol)} cannot be null.");
            _serializer = serializer ?? throw new ArgumentNullException($"{nameof(serializer)} cannot be null");
            _logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} cannot be null");
        }

        /// <summary>
        /// Creates a new OrientDB server connection.
        /// </summary>
        /// <returns>The created server connection.</returns>
        public IOrientServerConnection CreateConnection()
        {
            return _connectionProtocol.CreateServerConnection(_serializer, _logger);
        }
    }
}
