namespace Asland.Interfaces.Model.IO.DataEntry
{
    using System;
    using System.Collections.Generic;
    using Asland.Common.Enums;
    using Asland.Model.IO;

    /// <summary>
    /// Manages the input of raw observations for a single event.
    /// </summary>
    public interface IObservationManager
    {
        /// <summary>
        /// Gets the file name used for this event.
        /// </summary>
        string Filename { get; }

        /// <summary>
        /// Gets the year of this event.
        /// </summary>
        string Year { get; }

        /// <summary>
        /// Return the observations.
        /// </summary>
        /// <returns>raw observations</returns>
        RawObservations GetObservations();

        /// <summary>
        /// Get the location of the current entry
        /// </summary>
        /// <returns>current location</returns>
        string GetLocation();

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
        /// Set a new location in the model.
        /// </summary>
        /// <param name="newLocation">new location</param>
        void SetLocation(string newLocation);

        /// <summary>
        /// Set a new date in the model.
        /// </summary>
        /// <param name="newDate">new date</param>
        void SetDate(DateTime newDate);

        /// <summary>
        /// Update the notes in the model.
        /// </summary>
        /// <param name="newNotes">new notes</param>
        void SetNotes(string newNotes);

        /// <summary>
        /// Set a new length in the model.
        /// </summary>
        /// <param name="newLength">new length</param>
        void SetLength(ObservationLength newLength);

        /// <summary>
        /// Set a new intensity in the model.
        /// </summary>
        /// <param name="newIntensity">new intensity</param>
        void SetIntensity(ObservationIntensity newIntensity);

        /// <summary>
        /// Set a new time of day in the model.
        /// </summary>
        /// <param name="newTimeOfDay">new time of day</param>
        void SetTimeOfDay(ObservationTimeOfDay newTimeOfDay);

        /// <summary>
        /// Set a new weather in the model.
        /// </summary>
        /// <param name="newWeather">new weather</param>
        void SetWeather(ObservationWeather newWeather);

        /// <summary>
        /// Set a new collection of habitats in the model.
        /// </summary>
        /// <param name="newHabitats">new habitats</param>
        void SetHabitats(List<ObservationHabitat> newHabitats);

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
