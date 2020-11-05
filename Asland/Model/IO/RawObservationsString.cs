namespace Asland.Model.IO
{
    using System.Xml.Serialization;

    /// <summary>
    /// This class serialises the Raw Observation XML file where eash element is read as a string.
    /// </summary>
    [XmlRoot("RawObservations")]
    public class RawObservationsString
    {
        const string UnknownString = "Unknown";
        const string DefaultDateString = "01/01/1970";

        private string version;
        private string location;
        private string date;
        private string length;
        private string intensity;
        private string timeOfDay;
        private string weather;

        private HabitatsString habitats;
        private TypeString species;
        private TypeString heard;

        public RawObservationsString()
        {
            this.version = UnknownString;
            this.location = UnknownString;
            this.date = DefaultDateString;
            this.length = UnknownString;
            this.intensity = UnknownString;
            this.timeOfDay = UnknownString;
            this.weather = UnknownString;

            this.habitats = new HabitatsString();
            this.species = new TypeString();
            this.heard = new TypeString();
        }

        [XmlElement("ver")]
        public string Version
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

        [XmlElement("length")]
        public string Length
        {
            get
            {
                return this.length;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.length = value;
                }
                else
                {
                    this.length = UnknownString;
                }
            }
        }

        [XmlElement("intensity")]
        public string Intensity
        {
            get
            {
                return this.intensity;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.intensity = value;
                }
                else
                {
                    this.intensity = UnknownString;
                }
            }
        }

        [XmlElement("timeOfDay")]
        public string TimeOfDay
        {
            get
            {
                return this.timeOfDay;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.timeOfDay = value;
                }
                else
                {
                    this.timeOfDay = UnknownString;
                }
            }
        }

        [XmlElement("weather")]
        public string Weather
        {
            get
            {
                return this.weather;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.weather = value;
                }
                else
                {
                    this.weather = UnknownString;
                }
            }
        }

        [XmlElement("habitats")]
        public HabitatsString Habitats
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