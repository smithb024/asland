namespace Asland.Model.IO
{
    using System;
    using System.Xml.Serialization;
    using Asland.Common.Enums;

    [XmlRoot("RawObservations")]
    public class RawObservations
    {
        const string UnknownString = "Unknown";
        const string DefaultDateString = "01/01/1970";

        private int version;
        private string location;
        private string date;
        private ObservationLength length;
        private ObservationIntensity intensity;
        private ObservationTimeOfDay timeOfDay;

        public RawObservations()
        {
            this.version = 3;
            this.location = UnknownString;
            this.date = DefaultDateString;
            this.length = ObservationLength.Unspecified;
            this.intensity = ObservationIntensity.NotRecorded;
            this.timeOfDay = ObservationTimeOfDay.NotRecorded;
        }

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