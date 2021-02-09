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
        /// Model loaded event.
        /// </summary>
        event Action Loaded;

        /// <summary>
        /// Load a new set of observations from a file.
        /// </summary>
        /// <param name="newData">new observation data</param>
        /// <param name="filename">name of the file which has been loaded</param>
        /// <param name="year">year of the file which has been loaded</param>
        void LoadObservations(
            RawObservations newData,
            string filename,
            string year);

        /// <summary>
        /// Get the location of the current entry
        /// </summary>
        /// <returns>current location</returns>
        string GetLocation();

        /// <summary>
        /// Get a new date in the model.
        /// </summary>
        /// <returns>model date</returns>
        DateTime GetDate();

        /// <summary>
        /// Get the notes in the model.
        /// </summary>
        /// <returns>model notes</returns>
        string GetNotes();

        /// <summary>
        /// Get a new length in the model.
        /// </summary>
        /// <returns>model length</returns>
        ObservationLength GetLength();

        /// <summary>
        /// Get a new intensity in the model.
        /// </summary>
        /// <returns>model intensity</returns>
        ObservationIntensity GetIntensity();

        /// <summary>
        /// Get a new time of day in the model.
        /// </summary>
        /// <returns>model time of day</returns>
        ObservationTimeOfDay GetTimeOfDay();

        /// <summary>
        /// Get a new weather in the model.
        /// </summary>
        /// <returns>model weather</returns>
        ObservationWeather GetWeather();

        /// <summary>
        /// Get a new collection of habitats in the model.
        /// </summary>
        /// <returns>model habitats</returns>
        List<ObservationHabitat> GetHabitats();

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

        /// <summary>
        /// Reset the model.
        /// </summary>
        void Reset();
    }
}
