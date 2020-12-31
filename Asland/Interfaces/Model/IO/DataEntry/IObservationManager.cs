namespace Asland.Interfaces.Model.IO.DataEntry
{
    using Asland.Model.IO;

    /// <summary>
    /// Manages the input of raw observations for a single event.
    /// </summary>
    public interface IObservationManager
    {
        /// <summary>
        /// Return the observations.
        /// </summary>
        /// <returns>raw observations</returns>
        RawObservations GetObservations();

        /// <summary>
        /// Add or remove a beastie from the observations.
        /// </summary>
        /// <param name="name">Name of the beastie</param>
        /// <param name="isIncluded">
        /// Indicates whether to add or removed from the observation.
        /// </param>
        /// <param name="isSeen">
        /// Indicates whether the beastie is seen or heard.
        /// </param>
        void SetBeastie(
            string name,
            bool isIncluded,
            bool isSeen);

        /// <summary>
        /// Gets a value which indicates whether the <paramref name="name"/> is present in the model
        /// when searching the list indicated by <paramref name="isSeen"/>.
        /// </summary>
        /// <param name="name">Name of the beastie</param>
        /// <param name="isSeen">
        /// Indicates whether the beastie is seen or heard.
        /// </param>
        /// <returns>
        /// Indicates whether the beastie is currently present.
        /// </returns>
        bool GetIncluded(
            string name,
            bool isSeen);
    }
}
