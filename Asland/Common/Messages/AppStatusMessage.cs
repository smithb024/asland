namespace Asland.Common.Messages
{
    /// <summary>
    /// Application status message, used to indicate the latest known state.
    /// </summary>
    public class AppStatusMessage
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="AppStatusMessage"/> class.
        /// </summary>
        /// <param name="status">new status</param>
        public AppStatusMessage(string status)
        {
            this.Status = status;
        }

        /// <summary>
        /// Gets the status.
        /// </summary>
        public string Status { get; }
    }
}