namespace Asland.Model.IO
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Habitats as a string.
    /// </summary>
    public class HabitatsString
    {
        List<string> habitat;

        /// <summary>
        /// Initialises a new instance of the <see cref="HabitatsString"/> class.
        /// </summary>
        public HabitatsString()
        {
            this.habitat = new List<string>();
        }

        /// <summary>
        /// Gets or sets a collection of habitats.
        /// </summary>
        [XmlElement("habitat")]
        public List<string> Habitat
        {
            get => this.habitat;
            set => this.habitat = value;
        }
    }
}