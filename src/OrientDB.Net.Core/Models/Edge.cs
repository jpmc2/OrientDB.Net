using OrientDB.Net.Core.Attributes;
using System;

namespace OrientDB.Net.Core.Models
{
    /// <summary>
    /// Represents an edge in the OrientDB graph database.
    /// </summary>
    public class Edge : DictionaryOrientDBEntity
    {
        /// <summary>
        /// Gets the incoming vertex of the edge.
        /// </summary>
        [OrientDBProperty(Alias = "in", Serializable = false)]
        public ORID InV
        {
            get
            {
                //throw new NotImplementedException();
                return this.GetField<ORID>("in");
            }
        }

        /// <summary>
        /// Gets the outgoing vertex of the edge.
        /// </summary>
        [OrientDBProperty(Alias = "out", Serializable = false)]
        public ORID OutV
        {
            get
            {
                //throw new NotImplementedException();
                return this.GetField<ORID>("out");
            }
        }

        /// <summary>
        /// Gets the label of the edge.
        /// </summary>
        [OrientDBProperty(Alias = "label", Serializable = false)]
        public string Label
        {
            get
            {
                //throw new NotImplementedException();
                string label = GetField<string>("@OClassName");

                if (string.IsNullOrEmpty(label))
                {
                    return this.GetType().Name;
                }
                else
                {
                    return label;
                }
            }
        }
    }
}
