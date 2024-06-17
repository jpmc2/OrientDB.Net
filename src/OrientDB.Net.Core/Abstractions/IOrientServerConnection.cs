using OrientDB.Net.Core.Models;
using System.Collections.Generic;

namespace OrientDB.Net.Core.Abstractions
{
    /// <summary>
    /// Represents a connection to an OrientDB server.
    /// </summary>
    public interface IOrientServerConnection
    {
        /// <summary>
        /// Creates a new database with the specified name, database type, and storage type.
        /// </summary>
        /// <param name="database">The name of the database to create.</param>
        /// <param name="databaseType">The type of the database to create.</param>
        /// <param name="type">The storage type of the database to create.</param>
        /// <returns>The connection to the newly created database.</returns>
        IOrientDatabaseConnection CreateDatabase(string database, DatabaseType databaseType, StorageType type);

        /// <summary>
        /// Connects to an existing database with the specified name, database type, and optional pool size.
        /// </summary>
        /// <param name="database">The name of the database to connect to.</param>
        /// <param name="storageType">The type of the database to connect to.</param>
        /// <param name="poolSize">The optional pool size for the database connection.</param>
        /// <returns>The connection to the existing database.</returns>
        IOrientDatabaseConnection DatabaseConnect(string database, DatabaseType storageType, int poolSize = 10);

        /// <summary>
        /// Deletes the database with the specified name and storage type.
        /// </summary>
        /// <param name="database">The name of the database to delete.</param>
        /// <param name="storageType">The storage type of the database to delete.</param>
        void DeleteDatabase(string database, StorageType storageType);

        /// <summary>
        /// Checks if a database with the specified name and storage type exists.
        /// </summary>
        /// <param name="database">The name of the database to check.</param>
        /// <param name="storageType">The storage type of the database to check.</param>
        /// <returns><c>true</c> if the database exists; otherwise, <c>false</c>.</returns>
        bool DatabaseExists(string database, StorageType storageType);

        /// <summary>
        /// Shuts down the OrientDB server with the specified username and password.
        /// </summary>
        /// <param name="username">The username for authentication.</param>
        /// <param name="password">The password for authentication.</param>
        void Shutdown(string username, string password);

        /// <summary>
        /// Retrieves a list of all databases on the OrientDB server.
        /// </summary>
        /// <returns>An enumerable collection of database names.</returns>
        IEnumerable<string> ListDatabases();

        /// <summary>
        /// Retrieves the value of the specified configuration setting.
        /// </summary>
        /// <param name="name">The name of the configuration setting.</param>
        /// <returns>The value of the configuration setting.</returns>
        string GetConfigValue(string name);

        /// <summary>
        /// Sets the value of the specified configuration setting.
        /// </summary>
        /// <param name="name">The name of the configuration setting.</param>
        /// <param name="value">The value to set for the configuration setting.</param>
        void SetConfigValue(string name, string value);
    }
}
