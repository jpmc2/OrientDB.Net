using System;

namespace OrientDB.Net.Core.Models
{
    /// <summary>
    /// Represents a cluster in OrientDB.
    /// </summary>
    public class Cluster : IEquatable<Cluster>
    {
        /// <summary>
        /// Gets or sets the ID of the cluster.
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the cluster.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the cluster.
        /// </summary>
        public ClusterType Type { get; set; }

        [Obsolete]
        internal string Location { get; set; }
        [Obsolete]
        internal short DataSegmentID { get; set; }
        [Obsolete]
        internal string DataSegmentName { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current cluster.
        /// </summary>
        /// <param name="obj">The object to compare with the current cluster.</param>
        /// <returns>true if the specified object is equal to the current cluster; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            // if parameter cannot be cast to ORID return false.
            Cluster other = obj as Cluster;

            if (other == null)
            {
                return false;
            }

            return Equals(other);
        }

        /// <summary>
        /// Returns the hash code for the current cluster.
        /// </summary>
        /// <returns>A hash code for the current cluster.</returns>
        public override int GetHashCode()
        {
            return (Id * 17)
                ^ Name.GetHashCode()
                ^ Type.GetHashCode();
        }

        /// <summary>
        /// Determines whether two cluster objects are equal.
        /// </summary>
        /// <param name="left">The first cluster to compare.</param>
        /// <param name="right">The second cluster to compare.</param>
        /// <returns>true if the specified clusters are equal; otherwise, false.</returns>
        public static bool operator ==(Cluster left, Cluster right)
        {
            if (System.Object.ReferenceEquals(left, right))
            {
                return true;
            }

            if (((object)left == null) || ((object)right == null))
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two cluster objects are not equal.
        /// </summary>
        /// <param name="left">The first cluster to compare.</param>
        /// <param name="right">The second cluster to compare.</param>
        /// <returns>true if the specified clusters are not equal; otherwise, false.</returns>
        public static bool operator !=(Cluster left, Cluster right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the specified cluster is equal to the current cluster.
        /// </summary>
        /// <param name="other">The cluster to compare with the current cluster.</param>
        /// <returns>true if the specified cluster is equal to the current cluster; otherwise, false.</returns>
        public bool Equals(Cluster other)
        {
            if (other == null)
                return false;

            return Id == other.Id && String.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase) && Type == other.Type;
        }
    }
}
