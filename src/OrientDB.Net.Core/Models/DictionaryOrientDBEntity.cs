using System.Collections.Generic;

namespace OrientDB.Net.Core.Models
{
    /// <summary>
    /// Represents a dictionary-based OrientDB entity.
    /// </summary>
    public class DictionaryOrientDBEntity : OrientDBEntity
    {
        private readonly IDictionary<string, object> _fields = new Dictionary<string, object>();

        /// <summary>
        /// Gets the dictionary of fields.
        /// </summary>
        public IDictionary<string, object> Fields { get { return _fields; } }

        /// <summary>
        /// Gets the value of a field with the specified key.
        /// </summary>
        /// <typeparam name="T">The type of the field value.</typeparam>
        /// <param name="key">The key of the field.</param>
        /// <returns>The value of the field.</returns>
        public T GetField<T>(string key)
        {
            if (_fields.ContainsKey(key))
            {
                return (T)_fields[key];
            }
            return default(T);
        }

        /// <summary>
        /// Sets the value of a field with the specified key.
        /// </summary>
        /// <typeparam name="T">The type of the field value.</typeparam>
        /// <param name="key">The key of the field.</param>
        /// <param name="obj">The value to set.</param>
        public void SetField<T>(string key, T obj)
        {
            if (_fields.ContainsKey(key))
                _fields[key] = obj;
            else
                _fields.Add(key, obj);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryOrientDBEntity"/> class.
        /// </summary>
        public DictionaryOrientDBEntity()
        {

        }

        /// <summary>
        /// Hydrates the entity with the specified data.
        /// </summary>
        /// <param name="data">The data to hydrate the entity with.</param>
        public override void Hydrate(IDictionary<string, object> data)
        {
            foreach (var key in data.Keys)
            {
                if (_fields.ContainsKey(key))
                    _fields[key] = data[key];
                else
                    _fields.Add(key, data[key]);

            }
        }
    }
}
