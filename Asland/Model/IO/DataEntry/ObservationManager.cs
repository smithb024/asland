namespace Asland.Model.IO.DataEntry
{
    using System;
    using System.Collections.Generic;
    using Asland.Common.Enums;
    using Asland.Interfaces.Model.IO.DataEntry;
    using NynaeveLib.Utils;

    /// <summary>
    /// Manages the observations made in a single event.
    /// </summary>
    public class ObservationManager : IObservationManager
    {
        /// <summary>
        /// Indicates whether the filename can be changed.
        /// </summary>
        private bool lockName;

        /// <summary>
        /// The current event.
        /// </summary>
        private RawObservations observations;

        /// <summary>
        /// Portion of the filename based on the date.
        /// </summary>
        private string filenameDate;

        /// <summary>
        /// Initialises a new instance of the <see cref="ObservationManager"/> class.
        /// </summary>
        public ObservationManager()
        {
            this.observations = new RawObservations();
            this.Filename = string.Empty;
            this.Filename = string.Empty;
            this.lockName = false;
        }

        /// <summary>
        /// Gets the file name used for this event.
        /// </summary>
        public string Filename { get; private set; }

        /// <summary>
        /// Gets the year of this event.
        /// </summary>
        public string Year { get; private set; }

        /// <summary>
        /// Return the observations.
        /// </summary>
        /// <returns>raw observations</returns>
        public RawObservations GetObservations()
        {
            return this.observations;
        }

        /// <summary>
        /// Get the location of the current entry
        /// </summary>
        /// <returns>current location</returns>
        public string GetLocation()
        {
            return this.observations.Location;
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
        /// Set a new location in the model.
        /// </summary>
        /// <param name="newLocation">new location</param>
        public void SetLocation(string newLocation)
        {
            this.observations.Location = newLocation;
            this.SetFilename();
        }

        /// <summary>
        /// Set a new date in the model.
        /// </summary>
        /// <param name="newDate">new date</param>
        public void SetDate(DateTime newDate)
        {
            this.observations.Date = newDate.ToString("dd/MM/yyyy");

            if (!this.lockName)
            {
                this.filenameDate = newDate.ToString("yyMMdd") + "_" + DateTime.Now.ToString("HHmm");
                this.Year = newDate.Year.ToString();
            }

            this.SetFilename();
        }

        /// <summary>
        /// Update the notes in the model.
        /// </summary>
        /// <param name="newNotes">new notes</param>
        public void SetNotes(string newNotes)
        {
            this.observations.Notes = newNotes;
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

        /// <summary>
        /// Set a new collection of habitats in the model.
        /// </summary>
        /// <param name="newHabitats">new habitats</param>
        public void SetHabitats(List<ObservationHabitat> newHabitats)
        {
            this.observations.Habitats.Habitats = newHabitats;
        }

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

        /// <summary>
        /// Set the filename if it has not been locked.
        /// </summary>
        private void SetFilename()
        {
            if (!this.lockName)
            {
                this.Filename = $"{filenameDate}_{this.GetLocation()}.xml";
            }
        }
    }
}
