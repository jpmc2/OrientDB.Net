using System;
using Microsoft.Extensions.Logging;

namespace OrientDB.Net.Core.Configuration
{
    /// <summary>
    /// Represents the configuration for OrientDB logging.
    /// </summary>
    public class OrientDBLoggingConfiguration
    {
        private readonly OrientDBConfiguration _configuration;
        private readonly Action<ILogger> _loggerAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrientDBLoggingConfiguration"/> class.
        /// </summary>
        /// <param name="configuration">The OrientDB configuration.</param>
        /// <param name="loggerAction">The action to perform with the logger.</param>
        internal OrientDBLoggingConfiguration(OrientDBConfiguration configuration, Action<ILogger> loggerAction)
        {
            _configuration = configuration ?? throw new ArgumentNullException($"{nameof(configuration)} cannot be null.");
            _loggerAction = loggerAction ?? throw new ArgumentNullException($"{nameof(loggerAction)} cannot be null");
        }

        /// <summary>
        /// Sets the logger for OrientDB.
        /// </summary>
        /// <param name="logger">The logger to set.</param>
        /// <returns>The OrientDB configuration.</returns>
        public OrientDBConfiguration Logger(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException($"{nameof(logger)} cannot be null.");

            _loggerAction(logger);

            return _configuration;
        }
    }
}