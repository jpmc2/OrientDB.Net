namespace OrientDB.Net.Core.Abstractions
{
    /// <summary>
    /// Represents a logger for OrientDB operations.
    /// </summary>
    public interface IOrientDBLogger
    {
        /// <summary>
        /// Writes a debug message to the log.
        /// </summary>
        /// <param name="message">The debug message.</param>
        /// <param name="properties">Additional properties associated with the message.</param>
        void Debug(string message, params string[] properties);

        /// <summary>
        /// Writes an information message to the log.
        /// </summary>
        /// <param name="message">The information message.</param>
        /// <param name="properties">Additional properties associated with the message.</param>
        void Information(string message, params string[] properties);

        /// <summary>
        /// Writes a verbose message to the log.
        /// </summary>
        /// <param name="message">The verbose message.</param>
        /// <param name="properties">Additional properties associated with the message.</param>
        void Verbose(string message, params string[] properties);

        /// <summary>
        /// Writes an error message to the log.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="properties">Additional properties associated with the message.</param>
        void Error(string message, params string[] properties);

        /// <summary>
        /// Writes a fatal message to the log.
        /// </summary>
        /// <param name="message">The fatal message.</param>
        /// <param name="properties">Additional properties associated with the message.</param>
        void Fatal(string message, params string[] properties);

        /// <summary>
        /// Writes a warning message to the log.
        /// </summary>
        /// <param name="message">The warning message.</param>
        /// <param name="properties">Additional properties associated with the message.</param>
        void Warning(string message, params string[] properties);
    }
}
