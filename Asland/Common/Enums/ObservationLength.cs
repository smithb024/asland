namespace Asland.Common.Enums
{
    /// <summary>
    /// Length of time over which the observations were made.
    /// </summary>
    public enum ObservationLength
    {
        /// <summary>
        /// Short, less than 30 minutes
        /// </summary>
        S,

        /// <summary>
        /// Medium, between 30 minutes and less than 60 minutes.
        /// </summary>
        M,

        /// <summary>
        /// Long, Longer than an hour.
        /// </summary>
        L,

        /// <summary>
        /// Time is unspecified.
        /// </summary>
        Unspecified
    }
}