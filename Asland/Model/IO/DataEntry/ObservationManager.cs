namespace Asland.Model.IO.DataEntry
{
    using System;
    using System.Collections.Generic;
    using Asland.Common.Enums;
    using Asland.Common.Messages;
    using Asland.Interfaces.Model.IO.DataEntry;
    using NynaeveLib.Utils;
    using CommonMessenger = NynaeveLib.Messenger.Messenger;

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
            this.Reset();
        }

        /// <summary>
        /// Model loaded event.
        /// </summary>
        public event Action Loaded;

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
        /// Get a new date in the model.
        /// </summary>
        /// <returns>model date</returns>
        public DateTime GetDate()
        {
            bool conversionIsFaulty = false;
            int day = 0;
            int month = 0;
            int year = 0;
            DateTime returnDate;

            string[] dateArray = this.observations.Date.Split('/');

            if (dateArray.Length != 3)
            {
                conversionIsFaulty = true;
            }
            else
            {
                if (!int.TryParse(dateArray[0], out day))
                {
                    conversionIsFaulty = true;
                }

                if (!int.TryParse(dateArray[1], out month))
                {
                    conversionIsFaulty = true;
                }

                if (!int.TryParse(dateArray[2], out year))
                {
                    conversionIsFaulty = true;
                }
            }

            if (conversionIsFaulty)
            {
                AppStatusMessage message =
                    new AppStatusMessage(
                        $"Date {this.observations.Date} is invalid. Using Now.");
                CommonMessenger.Default.Send(message);
                returnDate = DateTime.Now;
            }
            else
            {
                returnDate =
                    new DateTime(
                        year,
                        month,
                        day);
            }

            return returnDate;
        }

        /// <summary>
        /// Get the notes in the model.
        /// </summary>
        /// <returns>model notes</returns>
        public string GetNotes()
        {
            return this.observations.Notes;
        }

        /// <summary>
        /// Get a new length in the model.
        /// </summary>
        /// <returns>model length</returns>
        public ObservationLength GetLength()
        {
            return this.observations.Length;
        }

        /// <summary>
        /// Get a new intensity in the model.
        /// </summary>
        /// <returns>model intensity</returns>
        public ObservationIntensity GetIntensity()
        {
            return this.observations.Intensity;
        }

        /// <summary>
        /// Get a new time of day in the model.
        /// </summary>
        /// <returns>model time of day</returns>
        public ObservationTimeOfDay GetTimeOfDay()
        {
            return this.observations.TimeOfDay;
        }

        /// <summary>
        /// Get a new weather in the model.
        /// </summary>
        /// <returns>model weather</returns>
        public ObservationWeather GetWeather()
        {
            return this.observations.Weather;
        }

        /// <summary>
        /// Get a new collection of habitats in the model.
        /// </summary>
        /// <returns>model habitats</returns>
        public List<ObservationHabitat> GetHabitats()
        {
            return this.observations.Habitats.Habitats;
        }

        /// <summary>
        /// Load a new set of observations from a file.
        /// </summary>
        /// <param name="newData">new observation data</param>
        /// <param name="filename">name of the file which has been loaded</param>
        /// <param name="year">year of the file which has been loaded</param>
        public void LoadObservations(
            RawObservations newData,
            string filename,
            string year)
        {
            this.observations = newData;
            this.Filename = filename;
            this.Year = year;
            this.lockName = true;

            this.Loaded?.Invoke();
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
        /// Reset the model.
        /// </summary>
        public void Reset()
        {
            this.observations = new RawObservations();
            this.Filename = string.Empty;
            this.Year = string.Empty;
            this.lockName = false;
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
