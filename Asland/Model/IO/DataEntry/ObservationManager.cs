namespace Asland.Model.IO.DataEntry
{
    using Asland.Common.Enums;
    using Asland.Interfaces.Model.IO.DataEntry;
    using NynaeveLib.Utils;

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

        /// <summary>
        /// Set a new length in the model.
        /// </summary>
        /// <param name="newLength">new length</param>
        public void SetLength(ObservationLength newLength)
        {
            this.observations.Length = newLength;
        }

        /// <summary>
        /// Set a new intensity in the model.
        /// </summary>
        /// <param name="newIntensity">new intensity</param>
        public void SetIntensity(ObservationIntensity newIntensity)
        {
            this.observations.Intensity = newIntensity;
        }

        /// <summary>
        /// Set a new time of day in the model.
        /// </summary>
        /// <param name="newTimeOfDay">new time of day</param>
        public void SetTimeOfDay(ObservationTimeOfDay newTimeOfDay)
        {
            this.observations.TimeOfDay = newTimeOfDay;
        }

        /// <summary>
        /// Set a new weather in the model.
        /// </summary>
        /// <param name="newWeather">new weather</param>
        public void SetWeather(ObservationWeather newWeather)
        {
            this.observations.Weather = newWeather;
        }

        ///// <summary>
        ///// Set a new habitat in the model.
        ///// </summary>
        ///// <param name="newHabitat">new habitat</param>
        //public void SetHabitat(ObservationHabitat newHabitat)
        //{
        //    this.observations.Habitats = newHabitat;
        //}

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
        public bool GetIncluded(
            string name,
            bool isSeen)
        {
            if (isSeen)
            {
                return this.observations.Species.Kind.Find(k => StringCompare.SimpleCompare(k, name)) != null;
            }

            return this.observations.Heard.Kind.Find(k => StringCompare.SimpleCompare(k, name)) != null; ;
        }
    }
}
