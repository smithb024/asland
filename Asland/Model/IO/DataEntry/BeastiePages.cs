namespace Asland.Model.IO.DataEntry
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Class used to serialise the pages within the Data Entry process.
    /// </summary>
    public class BeastiePages
    {
        /// <summary>
        /// Collection of all the pages in the data entry process.
        /// </summary>
        private List<Page> pages;

        /// <summary>
        /// Initialises a new instance of the <see cref="BeastiePages"/> class.
        /// </summary>
        public BeastiePages()
        {
            this.pages = new List<Page>();
        }

        /// <summary>
        /// Gets or sets a collection of each beastie page in the data entry process.
        /// </summary>
        [XmlElement("page")]
        public List<Page> Pages
        {
            get
            {
                return this.pages;
            }

            set
            {
                this.pages = value;
            }
        }
    }
}