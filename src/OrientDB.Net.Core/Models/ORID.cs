using System;

namespace OrientDB.Net.Core.Models
{
    /// <summary>
    /// Represents an OrientDB Record Identifier (ORID).
    /// </summary>
    public class ORID : IEquatable<ORID>
    {
        static readonly char[] colon = new char[] { ':' };

        /// <summary>
        /// Gets or sets the cluster ID of the ORID.
        /// </summary>
        public short ClusterId { get; set; }

        /// <summary>
        /// Gets or sets the cluster position of the ORID.
        /// </summary>
        public long ClusterPosition { get; set; }

        /// <summary>
        /// Gets or sets the string representation of the ORID.
        /// </summary>
        public string RID
        {
            get
            {
                return string.Format("#{0}:{1}", ClusterId, ClusterPosition);
            }

            set
            {
                int offset = 1;
                ClusterId = (short)FastParse(value, ref offset);
                offset += 1;
                ClusterPosition = FastParse(value, ref offset);
            }
        }

        /// <summary>
        /// Parses a string representation of an ORID and sets the ClusterId and ClusterPosition properties.
        /// </summary>
        /// <param name="s">The string representation of the ORID.</param>
        /// <param name="offset">The offset in the string to start parsing from.</param>
        /// <returns>The parsed long value.</returns>
        private long FastParse(string s, ref int offset)
        {
            long result = 0;
            short multiplier = 1;
            if (s[offset] == '-')
            {
                offset++;
                multiplier = -1;
            }

            while (offset < s.Length)
            {
                int iVal = s[offset] - '0';
                if (iVal < 0 || iVal > 9)
                    break;
                result = result * 10 + iVal;
                offset++;
            }

            return (result * multiplier);
        }

        /// <summary>
        /// Initializes a new instance of the ORID class with default values.
        /// </summary>
        public ORID()
        {
            ClusterId = -1;
            ClusterPosition = -1;
        }

        /// <summary>
        /// Initializes a new instance of the ORID class with the same values as another ORID instance.
        /// </summary>
        /// <param name="other">The ORID instance to copy the values from.</param>
        public ORID(ORID other)
        {
            ClusterId = other.ClusterId;
            ClusterPosition = other.ClusterPosition;
        }

        /// <summary>
        /// Initializes a new instance of the ORID class with the specified cluster ID and cluster position.
        /// </summary>
        /// <param name="clusterId">The cluster ID.</param>
        /// <param name="clusterPosition">The cluster position.</param>
        public ORID(short clusterId, long clusterPosition)
        {
            ClusterId = clusterId;
            ClusterPosition = clusterPosition;
        }

        /// <summary>
        /// Initializes a new instance of the ORID class with the specified string representation.
        /// </summary>
        /// <param name="orid">The string representation of the ORID.</param>
        public ORID(string orid)
        {
            RID = orid;
        }

        /// <summary>
        /// Initializes a new instance of the ORID class with the specified source string and offset.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="offset">The offset in the source string.</param>
        public ORID(string source, int offset)
        {
            if (source[offset] == '#')
                offset++;
            ClusterId = (short)FastParse(source, ref offset);
            offset += 1;
            ClusterPosition = FastParse(source, ref offset);
        }

        /// <summary>
        /// Returns the string representation of the ORID.
        /// </summary>
        /// <returns>The string representation of the ORID.</returns>
        public override string ToString()
        {
            return RID;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current ORID.
        /// </summary>
        /// <param name="obj">The object to compare with the current ORID.</param>
        /// <returns>true if the specified object is equal to the current ORID; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            ORID orid = obj as ORID;

            if (orid == null)
            {
                return false;
            }

            return Equals(orid);
        }

        /// <summary>
        /// Returns the hash code for the ORID.
        /// </summary>
        /// <returns>The hash code for the ORID.</returns>
        public override int GetHashCode()
        {
            return (ClusterId * 17) ^ ClusterPosition.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified ORID is equal to the current ORID.
        /// </summary>
        /// <param name="other">The ORID to compare with the current ORID.</param>
        /// <returns>true if the specified ORID is equal to the current ORID; otherwise, false.</returns>
        public bool Equals(ORID other)
        {
            if (other == null)
                return false;

            return ClusterId == other.ClusterId && ClusterPosition == other.ClusterPosition;
        }

        private static long _tempObjectId = -2;

        /// <summary>
        /// Generates a new ORID with a temporary cluster ID and decrements the temporary cluster position.
        /// </summary>
        /// <returns>A new ORID with a temporary cluster ID and decremented cluster position.</returns>
        public static ORID NewORID()
        {
            var orid = new ORID(-2, _tempObjectId);
            _tempObjectId = --_tempObjectId;
            return orid;
        }
    }
}
