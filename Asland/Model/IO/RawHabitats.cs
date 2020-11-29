namespace Asland.Model.IO
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using Common.Enums;

    /// <summary>
    /// Contains a list of habitats present during a set of observations.
    /// </summary>
    public class RawHabitats
    {
        /// <summary>
        /// Collection of habitats.
        /// </summary>
        List<ObservationHabitat> habitats;

        /// <summary>
        /// Initialises a new instance of the <see cref="RawHabitats"/> class.
        /// </summary>
        public RawHabitats()
        {
            this.habitats = new List<ObservationHabitat>();
        }

        /// <summary>
        /// Gets or sets the collection of habitats.
        /// </summary>
        [XmlElement("habitat")]
        public List<ObservationHabitat> Habitats
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
    }
}