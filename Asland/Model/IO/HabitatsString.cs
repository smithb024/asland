namespace Asland.Model.IO
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class HabitatsString
    {
        List<string> habitat;

        public HabitatsString()
        {
            this.habitat = new List<string>();
        }

        [XmlElement("habitat")]
        public List<string> Habitat
        {
            get
            {
                return this.habitat;
            }

            set
            {
                this.habitat = value;
            }
        }
    }
}