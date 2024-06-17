using OrientDB.Net.Core.Abstractions;
using System;

namespace OrientDB.Net.Core.Configuration
{
    /// <summary>
    /// Represents the configuration for an OrientDB connection.
    /// </summary>
    /// <typeparam name="TDataType">The type of data to be serialized and deserialized.</typeparam>
    public class OrientDBConnectionConfiguration<TDataType>
    {
        private readonly OrientDBConfiguration _configuration;
        private readonly Action<IOrientDBConnectionProtocol<TDataType>> _configAction;
        private readonly Action<IOrientDBRecordSerializer<TDataType>> _serializerAction;

        internal OrientDBConnectionConfiguration(
            OrientDBConfiguration configuration,
            Action<IOrientDBRecordSerializer<TDataType>> serializerAction,
            Action<IOrientDBConnectionProtocol<TDataType>> configAction)
        {
            _configuration = configuration ?? throw new ArgumentNullException($"{nameof(configuration)} cannot be null.");
            _configAction = configAction ?? throw new ArgumentNullException($"{nameof(configAction)} cannot be null.");
            _serializerAction = serializerAction ?? throw new ArgumentNullException($"{nameof(serializerAction)} cannot be null.");
        }

        /// <summary>
        /// Connects to the OrientDB server using the specified connection protocol.
        /// </summary>
        /// <param name="protocol">The connection protocol to use.</param>
        /// <returns>An instance of <see cref="OrientDBConnectionProtocolConfiguration{TDataType}"/>.</returns>
        public OrientDBConnectionProtocolConfiguration<TDataType> Connect(IOrientDBConnectionProtocol<TDataType> protocol)
        {
            if (protocol == null)
                throw new ArgumentNullException($"{nameof(protocol)} cannot be null.");

            _configAction(protocol);

            return new OrientDBConnectionProtocolConfiguration<TDataType>(_configuration, _serializerAction, _configAction);
        }
    }
}