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
        /// Initialises a new instance of the <see cref="RawObservations"/> class.
        /// </summary>
        public RawObservations()
        {
            this.version = 3;
            this.location = UnknownString;
            this.date = DefaultDateString;
            this.length = ObservationLength.Unspecified;
            this.intensity = ObservationIntensity.NotRecorded;
            this.timeOfDay = ObservationTimeOfDay.NotRecorded;
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
    }
}