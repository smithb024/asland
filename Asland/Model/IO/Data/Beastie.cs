namespace Asland.Model.IO.Data
{
    using System.Xml.Serialization;
    using Common.Enums;

    /// <summary>
    /// Class used to serialise and deserialise a single beastie.
    /// </summary>
    [XmlRoot("Beastie")]
    public class Beastie
    {
        /// <summary>
        /// The common name. This is used as a key.
        /// </summary>
        private string name;

        /// <summary>
        /// The common name, formatted such that it can be used on the displays.
        /// </summary>
        private string displayName;

        /// <summary>
        /// The latin name.
        /// </summary>
        private string latinName;

        /// <summary>
        /// The path to an image of the beastie.
        /// </summary>
        private string image;

        /// <summary>
        /// The path to a smaller image of the beastie.
        /// </summary>
        private string thumbnailImage;

        /// <summary>
        /// The size in centimeters
        /// </summary>
        private int size;

        /// <summary>
        /// The wingspan in centimeters.
        /// </summary>
        private int wingspan;

        /// <summary>
        /// Indicates when the beastie is present.
        /// </summary>
        private Presence presence;

        /// <summary>
        /// The genus of the beastie.
        /// </summary>
        private string genus;

        /// <summary>
        /// The genus of the beastie (latin)
        /// </summary>
        private string genusLatin;

        /// <summary>
        /// The sub family of the beastie.
        /// </summary>
        private string subFamily;

        /// <summary>
        /// The sub family of the beastie (latin)
        /// </summary>
        private string subFamilyLatin;

        /// <summary>
        /// The family of the beastie.
        /// </summary>
        private string family;

        /// <summary>
        /// The family of the beastie (latin)
        /// </summary>
        private string familyLatin;

        /// <summary>
        /// The order of the beastie.
        /// </summary>
        private string order;

        /// <summary>
        /// The order of the beastie (latin)
        /// </summary>
        private string orderLatin;

        /// <summary>
        /// The class of the beastie.
        /// </summary>
        private string classification;

        /// <summary>
        /// The class of the beastie (latin)
        /// </summary>
        private string classLatin;

        /// <summary>
        /// Initialises a new instance of the <see cref="Beastie"/> class.
        /// </summary>
        public Beastie()
        {
        }

        /// <summary>
        /// Gets or sets the common name.
        /// </summary>
        [XmlElement("name")]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the common display name.
        /// </summary>
        [XmlElement("displayName")]
        public string DisplayName
        {
            get
            {
                return this.displayName;
            }

            set
            {
                this.displayName = value;
            }
        }

        /// <summary>
        /// Gets or sets the latin name.
        /// </summary>
        [XmlElement("latinName")]
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
        [XmlElement("image")]
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

        /// <summary>
        /// Gets or sets the path to a smaller image of the beastie.
        /// </summary>
        [XmlElement("thumb")]
        public string ThumbnailImage
        {
            get
            {
                return this.thumbnailImage;
            }

            set
            {
                this.thumbnailImage = value;
            }
        }

        /// <summary>
        /// Gets or sets the size in centimeters.
        /// </summary>
        [XmlElement("sizeCm")]
        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
            }
        }

        /// <summary>
        /// Gets or sets the wingspan in centimeters.
        /// </summary>
        [XmlElement("wingspanCm")]
        public int Wingspan
        {
            get
            {
                return this.wingspan;
            }

            set
            {
                this.wingspan = value;
            }
        }

        /// <summary>
        /// Gets or sets the presence.
        /// </summary>
        [XmlElement("presence")]
        public Presence Presence
        {
            get
            {
                return this.presence;
            }

            set
            {
                this.presence = value;
            }
        }

        /// <summary>
        /// Gets or sets the genus of the beastie.
        /// </summary>
        [XmlElement("genus")]
        public string Genus
        {
            get
            {
                return this.genus;
            }

            set
            {
                this.genus = value;
            }
        }

        /// <summary>
        /// Gets or sets the genus of the beastie in latin.
        /// </summary>
        [XmlElement("genusLatin")]
        public string GenusLatin
        {
            get
            {
                return this.genusLatin;
            }

            set
            {
                this.genusLatin = value;
            }
        }

        /// <summary>
        /// Gets or sets the sub family of the beastie.
        /// </summary>
        [XmlElement("subFamily")]
        public string SubFamily
        {
            get
            {
                return this.subFamily;
            }

            set
            {
                this.subFamily = value;
            }
        }

        /// <summary>
        /// Gets or sets the sub family of the beastie in latin.
        /// </summary>
        [XmlElement("subFamilyLatin")]
        public string SubFamilyLatin
        {
            get
            {
                return this.subFamilyLatin;
            }

            set
            {
                this.subFamilyLatin = value;
            }
        }

        /// <summary>
        /// Gets or sets the family of the beastie.
        /// </summary>
        [XmlElement("family")]
        public string Family
        {
            get
            {
                return this.family;
            }

            set
            {
                this.family = value;
            }
        }

        /// <summary>
        /// Gets or sets the family of the beastie in latin.
        /// </summary>
        [XmlElement("familyLatin")]
        public string FamilyLatin
        {
            get
            {
                return this.familyLatin;
            }

            set
            {
                this.familyLatin = value;
            }
        }

        /// <summary>
        /// Gets or sets the order of the beastie.
        /// </summary>
        [XmlElement("order")]
        public string Order
        {
            get
            {
                return this.order;
            }

            set
            {
                this.order = value;
            }
        }

        /// <summary>
        /// Gets or sets the order of the beastie in latin.
        /// </summary>
        [XmlElement("orderLatin")]
        public string OrderLatin
        {
            get
            {
                return this.orderLatin;
            }

            set
            {
                this.orderLatin = value;
            }
        }

        /// <summary>
        /// Gets or sets the class of the beastie.
        /// </summary>
        [XmlElement("class")]
        public string Classification
        {
            get
            {
                return this.classification;
            }

            set
            {
                this.classification = value;
            }
        }

        /// <summary>
        /// Gets or sets the class of the beastie in latin.
        /// </summary>
        [XmlElement("classLatin")]
        public string ClassLatin
        {
            get
            {
                return this.classLatin;
            }

            set
            {
                this.classLatin = value;
            }
        }
    }
}
