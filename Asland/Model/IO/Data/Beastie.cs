namespace Asland.Model.IO.Data
{
    using System.Xml.Serialization;

    /// <summary>
    /// Class used to serialise and deserialise a single beastie.
    /// </summary>
    [XmlRoot("RawObservations")]
    public class Beastie
    {
        /// <summary>
        /// The common name.
        /// </summary>
        private string commonName;

        /// <summary>
        /// The latin name.
        /// </summary>
        private string latinName;

        /// <summary>
        /// The path to an image of the beastie.
        /// </summary>
        private string image;

        /// <summary>
        /// Initialises a new instance of the <see cref="Beastie"/> class.
        /// </summary>
        public Beastie()
        {
        }

        /// <summary>
        /// Gets or sets the common name.
        /// </summary>
        [XmlElement("page")]
        public string CommonName
        {
            get
            {
                return this.commonName;
            }

            set
            {
                this.commonName = value;
            }
        }

        /// <summary>
        /// Gets or sets the latin name.
        /// </summary>
        [XmlElement("page")]
        public string LatinName
        {
            get
            {
                return this.latinName;
            }

            set
            {
                this.latinName = value;
            }
        }

        /// <summary>
        /// Gets or sets the path to an image of the beastie.
        /// </summary>
        [XmlElement("page")]
        public string Image
        {
            get
            {
                return this.image;
            }

            set
            {
                this.image = value;
            }
        }
    }
}
