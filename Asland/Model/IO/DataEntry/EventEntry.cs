namespace Asland.Model.IO.DataEntry
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Asland.Common.Messages;
    using Asland.Interfaces;
    using Interfaces.Factories;
    using Interfaces.Model.IO.DataEntry;
    using Factories.IO;
    using GalaSoft.MvvmLight.Messaging;

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
        /// The logger.
        /// </summary>
        private IAsLogger logger;

        /// <summary>
        /// Initialises a new instance of the <see cref="EventEntry"/> class.
        /// </summary>
        /// <param name="dataFileFactory">Data file factory</param>
        /// <param name="logger">the logger</param>
        public EventEntry(
            IBeastieDataFileFactory dataFileFactory,
            IAsLogger logger)
        {
            this.Observations = new ObservationManager();
            this.logger = logger;
            this.rawPageData =
                XmlFileIo.ReadXml<BeastiePages>(
                    $"{DataPath.BasePath}\\TestDataEntry.xml");

            // Ensure that all data files exist.
            List<string> beastieNames = new List<string>();
            foreach(Page page in this.rawPageData.Pages)
            {
                beastieNames.AddRange(page.Beasties);
            }

            dataFileFactory.CheckFiles(
                beastieNames);
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
                string faultString = "Can't save, no location provided.";

                logger.WriteLine($"Event Entry Save: {faultString}");

                AppStatusMessage message =
                    new AppStatusMessage(
                        faultString);
                Messenger.Default.Send(message);

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
                string errorDescription = $"Error saving {this.Observations.Filename}";
                AppStatusMessage message =
                    new AppStatusMessage(
                        errorDescription);
                Messenger.Default.Send(message);

                this.logger.WriteLine(
                    $"Event Entry Save : {errorDescription}: {ex}");
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
                string errorDescription = $"Error loading {this.Observations.Filename}";
                AppStatusMessage message =
                    new AppStatusMessage(
                        errorDescription);
                Messenger.Default.Send(message);

                this.logger.WriteLine(
                    $"Event Entry Save : {errorDescription}: {ex}");
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