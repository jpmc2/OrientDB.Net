using System.Collections.Generic;

namespace OrientDB.Net.Core.Models
{
    /// <summary>
    /// Represents a vertex in the OrientDB graph database.
    /// </summary>
    public class Vertex : DictionaryOrientDBEntity
    {
        /// <summary>
        /// Gets the set of incoming edges for the vertex.
        /// </summary>
        public HashSet<ORID> InE
        {
            get
            {
                return this.GetField<HashSet<ORID>>("in_");
            }
        }

        /// <summary>
        /// Gets the set of outgoing edges for the vertex.
        /// </summary>
        public HashSet<ORID> OutE
        {
            get
            {
                return this.GetField<HashSet<ORID>>("out_");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vertex"/> class.
        /// </summary>
        public Vertex()
        {
            this.OClassName = "V";
        }
    }
}
