namespace Asland.Common.Enums
{
    /// <summary>
    /// Intensity of the observations.
    /// </summary>
    public enum ObservationIntensity
    {
        /// <summary>
        /// Not recorded.
        /// </summary>
        NotRecorded,

        /// <summary>
        /// Single instant in time.
        /// </summary>
        Snapshot,

        /// <summary>
        /// Low intensity birding, no bins.
        /// </summary>
        L,

        /// <summary>
        /// Medium intensity birding, bins but not paying too much attention, or paying attention
        /// with no bins.
        /// </summary>
        M,

        /// <summary>
        /// High intensity.
        /// </summary>
        H,

        /// <summary>
        /// Part of the commute to work.
        /// </summary>
        Commute,

        /// <summary>
        /// Running.
        /// </summary>
        Run,

        /// <summary>
        /// Cycling
        /// </summary>
        Cycling,

        /// <summary>
        /// Walking
        /// </summary>
        Walk,

        /// <summary>
        /// Railway journey
        /// </summary>
        RailJourney,

        /// <summary>
        /// Sea journey
        /// </summary>
        SeaJourney
    }
}