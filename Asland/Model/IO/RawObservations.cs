namespace Asland.Model.IO
{
    using System;
    using System.Xml.Serialization;
    using Asland.Common.Enums;

    /// <summary>
    /// Class used to serialise and deserialise the raw observations.
    /// </summary>
    [XmlRoot("RawObservations")]
    public class RawObservations
    {
        /// <summary>
        /// Default string for unknown data.
        /// </summary>
        const string UnknownString = "Unknown";

        /// <summary>
        /// Detault date.
        /// </summary>
        const string DefaultDateString = "01/01/1970";

        /// <summary>
        /// Version of the input file.
        /// </summary>
        private int version;

        /// <summary>
        /// Location of the observations.
        /// </summary>
        private string location;

        /// <summary>
        /// Date of the observations.
        /// </summary>
        private string date;

        /// <summary>
        /// Any pertinent notes for the observations.
        /// </summary>
        private string notes;

        /// <summary>
        /// Length of time the observations were taken over.
        /// </summary>
        private ObservationLength length;

        /// <summary>
        /// Observation intensity.
        /// </summary>
        private ObservationIntensity intensity;

        /// <summary>
        /// Time of day the observations were started.
        /// </summary>
        private ObservationTimeOfDay timeOfDay;

        /// <summary>
        /// The weather when the observations were made.
        /// </summary>
        private ObservationWeather weather;

        /// <summary>
        /// Habitats present during the observation.
        /// </summary>
        private RawHabitats habitats;

        /// <summary>
        /// Beasties observed.
        /// </summary>
        private TypeString species;

        /// <summary>
        /// Beasties heard.
        /// </summary>
        private TypeString heard;

        /// <summary>
        /// Initialises a new instance of the <see cref="RawObservations"/> class.
        /// </summary>
        public RawObservations()
        {
            this.version = 3;
            this.location = UnknownString;
            this.date = DefaultDateString;
            this.notes = string.Empty;
            this.length = ObservationLength.Unspecified;
            this.intensity = ObservationIntensity.NotRecorded;
            this.timeOfDay = ObservationTimeOfDay.NotRecorded;
            this.weather = ObservationWeather.NotRecorded;

            this.habitats = new RawHabitats();
            this.species = new TypeString();
            this.heard = new TypeString();
        }

        /// <summary>
        /// Gets or sets the observation file version.
        /// </summary>
        [XmlElement("ver")]
        public int Version
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
            }
        }

        /// <summary>
        /// Gets or sets the location of the observations.
        /// </summary>
        [XmlElement("location")]
        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.location = value;
                }
                else
                {
                    this.location = UnknownString;
                }
            }
        }

        /// <summary>
        /// Gets or sets the date of the observations.
        /// </summary>
        [XmlElement("date")]
        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.date = value;
                }
                else
                {
                    this.date = DefaultDateString;
                }
            }
        }

        /// <summary>
        /// Gets or sets any pertinent notes for the observations.
        /// </summary>
        [XmlElement("notes")]
        public string Notes
        {
            get
            {
                return this.notes;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.notes = value;
                }
                else
                {
                    this.notes = string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets or sets the length of time the observations were taken over.
        /// </summary>
        [XmlElement("length")]
        public ObservationLength Length
        {
            get
            {
                return this.length;
            }

            set
            {
                if (Enum.IsDefined(typeof(ObservationLength), value))
                {
                    this.length = value;
                }
                else
                {
                    this.length = ObservationLength.Unspecified;
                }
            }
        }

        /// <summary>
        /// Gets or sets the intensity of the observations.
        /// </summary>
        [XmlElement("intensity")]
        public ObservationIntensity Intensity
        {
            get
            {
                return this.intensity;
            }

            set
            {
                if (Enum.IsDefined(typeof(ObservationIntensity), value))
                {
                    this.intensity = value;
                }
                else
                {
                    this.intensity = ObservationIntensity.NotRecorded;
                }
            }
        }

        /// <summary>
        /// Gets or sets the time of day the observations were started.
        /// </summary>
        [XmlElement("timeOfDay")]
        public ObservationTimeOfDay TimeOfDay
        {
            get
            {
                return this.timeOfDay;
            }

            set
            {
                if (Enum.IsDefined(typeof(ObservationTimeOfDay), value))
                {
                    this.timeOfDay = value;
                }
                else
                {
                    this.timeOfDay = ObservationTimeOfDay.NotRecorded;
                }
            }
        }

        /// <summary>
        /// Gets or sets the weather present during the observations.
        /// </summary>
        [XmlElement("weather")]
        public ObservationWeather Weather
        {
            get
            {
                return this.weather;
            }

            set
            {
                if (Enum.IsDefined(typeof(ObservationWeather), value))
                {
                    this.weather = value;
                }
                else
                {
                    this.weather = ObservationWeather.NotRecorded;
                }
            }
        }

        [XmlElement("habitats")]
        public RawHabitats Habitats
        {
            get
            {
                return this.habitats;
            }

            set
            {
                this.habitats = value;
            }
        }

        /// <summary>
        /// Gets or sets the observed beasties.
        /// </summary>
        [XmlElement("species")]
        public TypeString Species
        {
            get
            {
                return this.species;
            }

            set
            {
                this.species = value;
            }
        }

        /// <summary>
        /// Gets or sets the heard beasties.
        /// </summary>
        [XmlElement("heard")]
        public TypeString Heard
        {
            get
            {
                return this.heard;
            }

            set
            {
                this.heard = value;
            }
        }
    }
}