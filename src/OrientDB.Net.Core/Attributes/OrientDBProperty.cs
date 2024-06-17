using OrientDB.Net.Core.Models;
using System;

namespace OrientDB.Net.Core.Attributes
{
    /// <summary>
    /// Specifies that a property is an OrientDB property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class OrientDBProperty : Attribute
    {
        /// <summary>
        /// Gets or sets the alias for the property.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the property is serializable.
        /// </summary>
        public bool Serializable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the property is deserializable.
        /// </summary>
        public bool Deserializable { get; set; }

        // TODO:
        /// <summary>
        /// Gets or sets the OrientDB type of the property.
        /// </summary>
        public OrientType Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrientDBProperty"/> class.
        /// </summary>
        public OrientDBProperty()
        {
            Alias = "";
            Serializable = true;
            Deserializable = true;
        }
    }
}
