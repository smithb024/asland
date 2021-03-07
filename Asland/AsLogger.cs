namespace Asland
{
    using Interfaces;
    using NynaeveLib.Logger;

    /// <summary>
    /// The logger class.
    /// </summary>
    /// <remarks>
    /// This manages the instance of the Nynaeve library logger.
    /// </remarks>
    public class AsLogger : IAsLogger
    {
        /// <summary>
        /// The library logger.
        /// </summary>
        private Logger logger;

        /// <summary>
        /// Initialises a new instance of the <see cref="AsLogger"/> class.
        /// </summary>
        public AsLogger()
        {
            Logger.SetInitialInstance("Asland");
            this.logger = Logger.Instance;
        }

        /// <summary>
        /// Write a line to the log file.
        /// </summary>
        /// <param name="logEntry">
        /// Line to add to the log file.
        /// </param>
        public void WriteLine(
            string logEntry)
        {
            this.logger.WriteLog(
                logEntry);
        }
    }
}