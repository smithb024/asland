namespace Asland.Model.IO
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class TypeString
    {
        private List<string> kind;

        public TypeString()
        {
            this.kind = new List<string>();
        }

        [XmlElement("kind")]
        public List<string> Kind
        {
            get
            {
                return this.kind;
            }

            set
            {
                this.kind = value;
            }
        }
    }
}