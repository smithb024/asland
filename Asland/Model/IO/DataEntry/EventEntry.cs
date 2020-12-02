namespace Asland.Model.IO.DataEntry
{
    using System.Collections.Generic;
    using Asland.Interfaces.Model.IO.DataEntry;
    using Factories.IO;

    /// <summary>
    /// Top class for the model which manages the entry of the events.
    /// </summary>
    public class EventEntry : IEventEntry
    {
        /// <summary>
        /// The current event.
        /// </summary>
        private RawObservations observations;

        /// <summary>
        /// The filename for the current event.
        /// </summary>
        private string filename;

        /// <summary>
        /// The page data from the configuration file.
        /// </summary>
        private BeastiePages rawPageData;

        /// <summary>
        /// Initialises a new instance of the <see cref="EventEntry"/> class.
        /// </summary>
        public EventEntry()
        {
            this.observations = new RawObservations();
            this.rawPageData =
                XmlFileIo.ReadXml<BeastiePages>(
                    $"{DataPath.BasePath}\\TestDataEntry.xml");
        }

        /// <summary>
        /// Save the current model.
        /// </summary>
        public void Save()
        {
            // TODO - Flesh out management of filename.
            XmlFileIo.WriteXml(
                this.observations,
                this.filename);
        }

        /// <summary>
        /// Load a model to edit.
        /// </summary>
        public void Load()
        {
        }

        /// <summary>
        /// Clear the existing model and reset to default.
        /// </summary>
        public void Clear()
        {
        }

        /// <summary>
        /// Gets a list of all the pages defined in the configuration file.
        /// </summary>
        /// <returns>Predefined page names</returns>
        public List<string> GetDataEntryPageNames()
        {
            List<string> pages = new List<string>();

            foreach(Page page in this.rawPageData.Pages)
            {
                pages.Add(page.Name);
            }

            return pages;
        }

        /// <summary>
        /// Gets a list of all the beastie on a specific page, as defined by the configuration 
        /// file.
        /// </summary>
        /// <param name="pageName">
        /// Name of the page to search for.
        /// </param>
        /// <returns>
        /// Predefined beastie name.
        /// </returns>
        public List<string> GetBeastiesOnAPage(string pageName)
        {
            foreach (Page page in this.rawPageData.Pages)
            {
                if (string.Equals(page.Name, pageName))
                {
                    return page.Beasties;
                }
            }

            return new List<string>();
        }
    }
}