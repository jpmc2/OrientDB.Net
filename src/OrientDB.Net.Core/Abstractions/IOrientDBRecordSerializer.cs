using OrientDB.Net.Core.Models;

namespace OrientDB.Net.Core.Abstractions
{
    /// <summary>
    /// Represents an interface for serializing and deserializing OrientDB records.
    /// </summary>
    /// <typeparam name="TDataType">The type of the data to be serialized or deserialized.</typeparam>
    public interface IOrientDBRecordSerializer<TDataType>
    {
        /// <summary>
        /// Gets the record format used by the serializer.
        /// </summary>
        OrientDBRecordFormat RecordFormat { get; }

        /// <summary>
        /// Deserializes the specified data into an instance of the specified result type.
        /// </summary>
        /// <typeparam name="TResultType">The type of the result object.</typeparam>
        /// <param name="data">The data to be deserialized.</param>
        /// <returns>An instance of the specified result type.</returns>
        TResultType Deserialize<TResultType>(TDataType data) where TResultType : OrientDBEntity;

        /// <summary>
        /// Serializes the specified input object into the data type.
        /// </summary>
        /// <typeparam name="T">The type of the input object.</typeparam>
        /// <param name="input">The input object to be serialized.</param>
        /// <returns>The serialized data.</returns>
        TDataType Serialize<T>(T input) where T : OrientDBEntity;
    }
}
