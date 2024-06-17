using OrientDB.Net.Core.Models;
using System.Collections.Generic;

namespace OrientDB.Net.Core.Abstractions
{
    /// <summary>
    /// Represents the result of an OrientDB command execution.
    /// </summary>
    public interface IOrientDBCommandResult
    {
        /// <summary>
        /// Gets the number of records affected by the command.
        /// </summary>
        int RecordsAffected { get; }

        /// <summary>
        /// Gets the collection of updated records returned by the command.
        /// </summary>
        IEnumerable<DictionaryOrientDBEntity> UpdatedRecords { get; }
    }
}
