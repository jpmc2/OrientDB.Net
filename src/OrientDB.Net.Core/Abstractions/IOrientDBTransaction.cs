using OrientDB.Net.Core.Models;

namespace OrientDB.Net.Core.Abstractions
{
    /// <summary>
    /// Represents a transaction in OrientDB.
    /// </summary>
    public interface IOrientDBTransaction
    {
        /// <summary>
        /// Adds an entity to the transaction.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="entity">The entity to add.</param>
        void AddEntity<T>(T entity) where T : OrientDBEntity;

        /// <summary>
        /// Removes an entity from the transaction.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="entity">The entity to remove.</param>
        void Remove<T>(T entity) where T : OrientDBEntity;

        /// <summary>
        /// Updates an entity in the transaction.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="entity">The entity to update.</param>
        void Update<T>(T entity) where T : OrientDBEntity;

        /// <summary>
        /// Adds an edge to the transaction.
        /// </summary>
        /// <param name="edge">The edge to add.</param>
        /// <param name="from">The starting vertex of the edge.</param>
        /// <param name="to">The ending vertex of the edge.</param>
        void AddEdge(Edge edge, Vertex from, Vertex to);

        /// <summary>
        /// Commits the transaction.
        /// </summary>
        void Commit();

        /// <summary>
        /// Resets the transaction.
        /// </summary>
        void Reset();
    }
}