using OrientDB.Net.Core.Abstractions;
using System;

namespace OrientDB.Net.Core.Configuration
{
    /// <summary>
    /// Represents the configuration for serialization in OrientDB.
    /// </summary>
    /// <typeparam name="TDataType">The type of data to be serialized.</typeparam>
    public class OrientDBSerializationConfiguration<TDataType>
    {
        private readonly OrientDBConfiguration _configuration;
        private readonly Action<IOrientDBRecordSerializer<TDataType>> _addSerializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrientDBSerializationConfiguration{TDataType}"/> class.
        /// </summary>
        /// <param name="configuration">The OrientDB configuration.</param>
        /// <param name="addSerializer">The action to add a serializer.</param>
        internal OrientDBSerializationConfiguration(
            OrientDBConfiguration configuration,
            Action<IOrientDBRecordSerializer<TDataType>> addSerializer)
        {
            _configuration = configuration ?? throw new ArgumentNullException($"{nameof(configuration)} cannot be null.");
            _addSerializer = addSerializer ?? throw new ArgumentNullException($"{nameof(addSerializer)} cannot be null.");
        }

        /// <summary>
        /// Sets the serializer for the specified data type.
        /// </summary>
        /// <param name="serializer">The serializer to be set.</param>
        /// <returns>The OrientDB configuration.</returns>
        public OrientDBConfiguration Serializer(IOrientDBRecordSerializer<TDataType> serializer)
        {
            if (serializer == null)
                throw new ArgumentNullException($"{nameof(serializer)} cannot be null.");

            _addSerializer(serializer);

            return _configuration;
        }
    }
}