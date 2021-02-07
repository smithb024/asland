namespace Asland.Model.IO.DataEntry
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Asland.Interfaces.Model.IO.Data;
    using Asland.Interfaces.Model.IO.DataEntry;
    using Factories;
    using Factories.IO;

    /// <summary>
    /// Top class for the model which manages the entry of the events.
    /// </summary>
    public class EventEntry : IEventEntry
    {
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
        /// <param name="dataManager">Data IO Manager</param>
        public EventEntry(
            IDataManager dataManager)
        {
            this.Observations = new ObservationManager();
            this.rawPageData =
                XmlFileIo.ReadXml<BeastiePages>(
                    $"{DataPath.BasePath}\\TestDataEntry.xml");

            // Ensure that all data files exist.
            List<string> beastieNames = new List<string>();
            foreach(Page page in this.rawPageData.Pages)
            {
                beastieNames.AddRange(page.Beasties);
            }

            BeastieDataFileFactory.CheckFiles(
                beastieNames,
                dataManager);
        }

        /// <summary>
        /// Gets the manager class for the current observations.
        /// </summary>
        public IObservationManager Observations { get; }

        /// <summary>
        /// Save the current model.
        /// </summary>
        /// <returns>success flag</returns>
        public bool Save()
        {
            if (string.IsNullOrWhiteSpace(this.Observations.GetLocation()))
            {
                // TODO #26 Handle Faults.
                return false;
            }

            string path = $"{DataPath.RawDataPath}\\{this.Observations.Year}";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            try
            {
                XmlFileIo.WriteXml(
                    this.Observations.GetObservations(),
                    $"{path}\\{this.Observations.Filename}");
            }
            catch (Exception ex)
            {
                // TODO #26 Error saving file - Need to note this.
                string error = ex.ToString();
            }

            this.Observations.Reset();

            return true;
        }

        /// <summary>
        /// Load a model to edit.
        /// </summary>
        /// <param name="path">path of the file to load</param>
        public void Load(string path)
        {
            this.Observations.Reset();

            try
            {
                string filename = Path.GetFileName(path);
                string year = Path.GetFileName(Path.GetDirectoryName(path));

                RawObservations observations =
                    XmlFileIo.ReadXml<RawObservations>(
                        path);

                this.Observations.LoadObservations(
                    observations,
                    filename,
                    year);
            }
            catch (Exception ex)
            {
                // TODO #26 Error loading file - Need to note this.
                string error = ex.ToString();
            }
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