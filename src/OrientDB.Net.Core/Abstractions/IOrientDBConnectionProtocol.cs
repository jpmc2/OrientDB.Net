using Microsoft.Extensions.Logging;
using System;

namespace OrientDB.Net.Core.Abstractions
{
    /// <summary>
    /// Represents the interface for the OrientDB connection protocol.
    /// </summary>
    /// <typeparam name="TDataType">The type of data to be serialized.</typeparam>
    public interface IOrientDBConnectionProtocol<TDataType> : IDisposable
    {
        /// <summary>
        /// Creates a server connection using the specified serializer and logger.
        /// </summary>
        /// <param name="serializer">The serializer to be used for data serialization.</param>
        /// <param name="logger">The logger to be used for logging.</param>
        /// <returns>The created server connection.</returns>
        IOrientServerConnection CreateServerConnection(IOrientDBRecordSerializer<TDataType> serializer, ILogger logger);
    }
}
