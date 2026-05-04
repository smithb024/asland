namespace Asland.Factories
{
    using Asland.Interfaces;
    using Asland.Interfaces.Factories;
    using Asland.Interfaces.Model.IO.Data;
    using Asland.Factories.IO;
    using Asland.Model.IO;
    using Asland.Model.IO.Data;
    using NynaeveLib.Logger;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// The object with manages search access to the beasties. 
    /// </summary>
    public class BeastieSearchFactory : IBeastieSearchFactory
    {
        /// <summary>
        ///  The data manager.
        /// </summary>
        private readonly IDataManager dataManager;

        /// <summary>
        /// The path Manager.
        /// </summary>
        private readonly IPathManager pathManager;

        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieDataFileFactory"/> class.
        /// </summary>
        /// <param name="dataManager">The data manager</param>
        /// <param name="pathManager">The path manager</param>
        public BeastieSearchFactory(
            IDataManager dataManager,
            IPathManager pathManager)
        {
            this.dataManager = dataManager;
            this.pathManager = pathManager;
        }

        /// <summary>
        /// Get a list of all known beasties.
        /// </summary>
        /// <returns>beastie names</returns>
        public Dictionary<string, string> FindAllNames()
        {
            Dictionary<string, string> names = 
                new Dictionary<string, string>();

            foreach (Beastie beastie in this.dataManager.Beasties)
            {
                names.Add(
                    beastie.Name, 
                    beastie.DisplayName);
            }

            return names;
        }

        /// <summary>
        /// Find and return a specific beastie
        /// </summary>
        /// <param name="name">name to search for</param>
        /// <returns>found beastie</returns>
        public Beastie Find(string name)
        {
            Beastie foundBeastie =
                this.dataManager.Beasties.Find(
                    b => string.Compare(b.Name, name) == 0);

            return foundBeastie;
        }

        /// <summary>
        /// Find and return data for a specific beastie.
        /// </summary>
        /// <remarks>
        /// It returns the data by calling <paramref name="beastieAction"/> for each observation 
        /// containing the named beastie.
        /// </remarks>
        /// <param name="beastieAction">
        /// The action which is used to pass the found raw data back to the calling class.
        /// </param>
        /// <param name="countLocation">
        /// The action which used to pass a location name back to the calling class. Every 
        /// location should be sent so that they can all be counted.
        /// </param>
        /// <param name="complete">
        /// The action which is used to indicate that the job has been completed.
        /// </param>
        /// <param name="name">name to search for</param>
        public void Find(
            Action<RawObservationsString> locationAction,
            Action<string> countLocation,
            Action complete,
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

                            countLocation.Invoke(raw.Location);

                            // Only interested if the location is equal to the name.
                            if (!raw.Species.Kind.Contains(name) &&
                                !raw.Heard.Kind.Contains(name))
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

                    complete.Invoke();
                }
                catch (NullReferenceException ex)
                {
                    Logger.Instance.WriteLog(
                        $"Beastie Search Factory Failed opening raw file: {ex}");
                }
            });
        }
    }
}
