using OrientDB.Net.Core.Abstractions;
using OrientDB.Net.Core.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace OrientDB.Net.Core.Data
{
    /// <summary>
    /// Represents a connection to an OrientDB database.
    /// </summary>
    /// <typeparam name="TDataType">The type of data to be serialized and deserialized.</typeparam>
    public class OrientConnection<TDataType> : IOrientDatabaseConnection
    {
        private readonly ILogger _logger;

        private readonly IOrientServerConnection _serverConnection;
        private readonly IOrientDatabaseConnection _databaseConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrientConnection{TDataType}"/> class.
        /// </summary>
        /// <param name="serializer">The serializer used to serialize and deserialize data.</param>
        /// <param name="connectionProtocol">The connection protocol used to communicate with the server.</param>
        /// <param name="logger">The logger used for logging.</param>
        /// <param name="database">The name of the database.</param>
        /// <param name="databaseType">The type of the database.</param>
        /// <param name="poolSize">The size of the connection pool.</param>
        internal OrientConnection(
            IOrientDBRecordSerializer<TDataType> serializer,
            IOrientDBConnectionProtocol<TDataType> connectionProtocol,
            ILogger logger,
            string database,
            DatabaseType databaseType,
            int poolSize = 10)
        {
            if (serializer == null) throw new ArgumentNullException($"{nameof(serializer)}");
            if (connectionProtocol == null) throw new ArgumentNullException($"{nameof(connectionProtocol)}");
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentException($"{nameof(database)}");
            _logger = logger ?? throw new ArgumentNullException($"{nameof(logger)}");

            _serverConnection = connectionProtocol.CreateServerConnection(serializer, logger);
            _databaseConnection = _serverConnection.DatabaseConnect(database, databaseType, poolSize);
        }

        /// <summary>
        /// Executes a SQL query and returns the result.
        /// </summary>
        /// <typeparam name="TResultType">The type of the result.</typeparam>
        /// <param name="sql">The SQL query to execute.</param>
        /// <returns>The result of the query.</returns>
        /// <exception cref="ArgumentException">Thrown when the SQL query is null or empty.</exception>
        public IEnumerable<TResultType> ExecuteQuery<TResultType>(string sql) where TResultType : OrientDBEntity
        {
            if (string.IsNullOrWhiteSpace(sql))
                throw new ArgumentException($"{nameof(sql)} cannot be zero length or null");
            _logger.LogDebug($"Executing SQL Query: {sql}");
            var data = _databaseConnection.ExecuteQuery<TResultType>(sql);
            return data;
        }

        /// <summary>
        /// Executes a SQL command and returns the result.
        /// </summary>
        /// <param name="sql">The SQL command to execute.</param>
        /// <returns>The result of the command.</returns>
        /// <exception cref="ArgumentException">Thrown when the SQL command is null or empty.</exception>
        public IOrientDBCommandResult ExecuteCommand(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql))
                throw new ArgumentException($"{nameof(sql)} cannot be zero length or null");
            _logger.LogDebug($"Executing SQL Command: {sql}");
            var data = _databaseConnection.ExecuteCommand(sql);
            return data;
        }

        /// <summary>
        /// Executes a prepared SQL query with parameters and returns the result.
        /// </summary>
        /// <typeparam name="TResultType">The type of the result.</typeparam>
        /// <param name="sql">The SQL query to execute.</param>
        /// <param name="parameters">The parameters for the query.</param>
        /// <returns>The result of the query.</returns>
        /// <exception cref="ArgumentException">Thrown when the SQL query is null or empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public IEnumerable<TResultType> ExecutePreparedQuery<TResultType>(string sql, params string[] parameters) where TResultType : OrientDBEntity
        {
            if (string.IsNullOrWhiteSpace(sql))
                throw new ArgumentException($"{nameof(sql)} cannot be zero length or null");
            if (parameters == null)
                throw new ArgumentNullException($"{nameof(parameters)} cannot be null");
            _logger.LogDebug($"Executing SQL Query: {sql}");
            var data = _databaseConnection.ExecutePreparedQuery<TResultType>(sql, parameters);
            return data;
        }

        /// <summary>
        /// Creates a new transaction.
        /// </summary>
        /// <returns>The new transaction.</returns>
        public IOrientDBTransaction CreateTransaction()
        {
            return _databaseConnection.CreateTransaction();
        }

        /// <summary>
        /// Disposes of the connection.
        /// </summary>
        /// <param name="disposing">True if called from Dispose(), false if called from the finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _databaseConnection?.Dispose();
            }
        }

        /// <summary>
        /// Disposes of the connection.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
