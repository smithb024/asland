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

    /// <summary>
    /// Factory which is used to search for location data.
    /// </summary>
    public class LocationSearchFactory : ILocationSearchFactory
    {
        /// <summary>
        /// The path Manager.
        /// </summary>
        private IPathManager pathManager;

        /// <summary>
        /// Initialises a new instance of the <see cref="IPathManager"/> class.
        /// </summary>
        /// <param name="pathManager">The path manager</param>
        public LocationSearchFactory(IPathManager pathManager) 
        {
            this.pathManager = pathManager;
        }

        /// <summary>
        /// Find and return data for a specific location.
        /// </summary>
        /// <param name="locationAction">
        /// The action which is used to pass the found location back to the calling class.
        /// </param>
        /// <param name="name">name to search for</param>
        public void Find(
            Action<RawObservationsString> locationAction,
            string name)
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
                        string[] rawFiles = Directory.GetFiles(directory);

                        foreach (string file in rawFiles)
                        {
                            RawObservationsString raw =
                                XmlFileIo.ReadXml<RawObservationsString>(
                                    file);

                            // Only interested if the location is equal to the name.
                            if (!string.Equals(raw.Location, name, StringComparison.OrdinalIgnoreCase))
                            {
                                continue;
                            }

                            // Pass the deserialised file to the view model on the UI thread.
                            App.Current.Dispatcher.Invoke(
                                new Action(() =>
                                {
                                    locationAction.Invoke(raw);
                                }));
                        }
                    }
                }
                catch (NullReferenceException ex)
                {
                    Logger.Instance.WriteLog(
                        $"Failed opening raw file: {ex}");
                }
            });
        }
    }
}