namespace Asland.Factories
{
    using Asland.Factories.IO;
    using Asland.Interfaces;
    using Asland.Interfaces.Factories;
    using Asland.Model.IO;
    using NynaeveLib.Logger;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    /// <summary>
    /// Factory which is used to search for data across a specific time period.
    /// </summary>
    public class TimeSearchFactory : ITimeSearchFactory
    {
        /// <summary>
        /// The path Manager.
        /// </summary>
        private readonly IPathManager pathManager;

        /// <summary>
        /// Initialises a new instance of the <see cref="TimeSearchFactory"/> class.
        /// </summary>
        /// <param name="pathManager">The path manager</param>
        public TimeSearchFactory(IPathManager pathManager) 
        {
            this.pathManager = pathManager;
        }

        /// <summary>
        /// Find and return data for a specific year.
        /// </summary>
        /// <param name="timeAction">
        /// The action which is used to pass the found data back to the calling class.
        /// </param>
        /// <param name="year">year to search for</param>
        public void Find(
            Action<RawObservationsString> timeAction,
            string year)
        {
            Task.Run(() =>
            {
                // Get the collection of all files.
                string[] subdirectoryEntries =
                    Directory.GetDirectories(
                        this.pathManager.RawDataPath);

                try
                {
                    // Loop through the files and open each on in turn.
                    foreach (string directory in subdirectoryEntries)
                    {
                        // Only interested if the year is equal to the input.
                        if (!string.Equals(year, Path.GetFileName(directory), StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        string[] rawFiles = Directory.GetFiles(directory);

                        foreach (string file in rawFiles)
                        {
                            RawObservationsString raw =
                                XmlFileIo.ReadXml<RawObservationsString>(
                                    file);

                            // Pass the deserialised file to the view model on the UI thread.
                            App.Current.Dispatcher.Invoke(
                                new Action(() =>
                                {
                                    timeAction.Invoke(raw);
                                }));
                        }
                    }
                }
                catch (NullReferenceException ex)
                {
                    Logger.Instance.WriteLog(
                        $"Time Search Factory Failed opening raw file: {ex}");
                }
            });
        }
    }
}