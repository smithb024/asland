namespace Asland.Model.IO.DataEntry
{
    using Asland.Interfaces.Model.IO.DataEntry;

    /// <summary>
    /// Manages the observations made in a single event.
    /// </summary>
    public class ObservationManager : IObservationManager
    {
        /// <summary>
        /// The current event.
        /// </summary>
        private RawObservations observations;


        public ObservationManager()
        {
            this.observations = new RawObservations();
        }

        /// <summary>
        /// Return the observations.
        /// </summary>
        /// <returns>raw observations</returns>
        public RawObservations GetObservations()
        {
            return this.observations;
        }

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
        public void SetBeastie(
            string name,
            bool isIncluded,
            bool isSeen)
        {
            this.SetBeastie(
                name,
                isSeen ? this.observations.Species : this.observations.Heard,
                isIncluded);
        }

        /// <summary>
        /// Add or remove a beastie from the specified <paramref name="observations"/>.
        /// </summary>
        /// <param name="name">beastie name</param>
        /// <param name="observations">observations to manage</param>
        /// <param name="isIncluded">
        ///  Indicates whether to add or remove from the observations.
        /// </param>
        private void SetBeastie(
            string name,
            TypeString observations,
            bool isIncluded)
        {
            if (isIncluded)
            {
                observations.Kind.Add(name);
            }
            else
            {
                observations.Kind.Remove(name);
            }
        }

    }
}
