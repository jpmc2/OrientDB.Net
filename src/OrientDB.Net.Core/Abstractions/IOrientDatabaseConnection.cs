using System;
using OrientDB.Net.Core.Models;
using System.Collections.Generic;

namespace OrientDB.Net.Core.Abstractions
{
    /// <summary>
    /// Represents a connection to an OrientDB database.
    /// </summary>
    public interface IOrientDatabaseConnection : IDisposable
    {
        /// <summary>
        /// Executes a SQL query and returns the result as a collection of entities.
        /// </summary>
        /// <typeparam name="TResultType">The type of the entities to return.</typeparam>
        /// <param name="sql">The SQL query to execute.</param>
        /// <returns>A collection of entities.</returns>
        IEnumerable<TResultType> ExecuteQuery<TResultType>(string sql) where TResultType : OrientDBEntity;

        /// <summary>
        /// Executes a prepared SQL query with parameters and returns the result as a collection of entities.
        /// </summary>
        /// <typeparam name="TResultType">The type of the entities to return.</typeparam>
        /// <param name="sql">The SQL query to execute.</param>
        /// <param name="parameters">The parameters for the prepared query.</param>
        /// <returns>A collection of entities.</returns>
        IEnumerable<TResultType> ExecutePreparedQuery<TResultType>(string sql, params string[] parameters) where TResultType : OrientDBEntity;

        /// <summary>
        /// Executes a SQL command.
        /// </summary>
        /// <param name="sql">The SQL command to execute.</param>
        /// <returns>The result of the command execution.</returns>
        IOrientDBCommandResult ExecuteCommand(string sql);

        /// <summary>
        /// Creates a new transaction for the database connection.
        /// </summary>
        /// <returns>A new transaction.</returns>
        IOrientDBTransaction CreateTransaction();
    }
}
