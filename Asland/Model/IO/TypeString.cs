namespace Asland.Model.IO
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Class used to serialise and deserialise a collection of beasties in the raw observations.
    /// </summary>
    public class TypeString
    {
        /// <summary>
        /// The list of beasties which are present.
        /// </summary>
        private List<string> kind;

        /// <summary>
        /// Initialises a new instance of the <see cref="TypeString"/> class.
        /// </summary>
        public TypeString()
        {
            this.kind = new List<string>();
        }

        /// <summary>
        /// Gets the collection of different beasties which are present.
        /// </summary>
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