namespace Asland.Model.IO.DataEntry
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Class used to serialise the contents of a page within the Data Entry process.
    /// </summary>
    public class Page
    {
        /// <summary>
        /// Name of the page.
        /// </summary>
        private string name;

        /// <summary>
        /// List of all the beasties on this page.
        /// </summary>
        private List<string> beasties;

        /// <summary>
        /// Initialises a new instance of the <see cref="Page"/> class.
        /// </summary>
        public Page()
        {
            this.name = string.Empty;
            this.beasties = new List<string>();
        }

        /// <summary>
        /// Gets or set a collection off all the beasties on the page.
        /// </summary>
        [XmlAttribute("name")]
        public string Name
        {
            get => this.name;

            set => this.name = value;
        }

        /// <summary>
        /// Gets or set a collection off all the beasties on the page.
        /// </summary>
        [XmlElement("beastie")]
        public List<string> Beasties
        {
            get => this.beasties;
            set => this.beasties = value;
        }
    }
}