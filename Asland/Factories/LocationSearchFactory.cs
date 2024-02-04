using Asland.Factories.IO;
using Asland.Model.IO;
using NynaeveLib.Logger;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asland.Factories
{
    /// <summary>
    /// Factory which is used to search for location data.
    /// </summary>
    public class LocationSearchFactory
    {
        /// <summary>
        /// Find and return data for a specific location.
        /// </summary>
        /// <param name="locationAction">
        /// The action which is used to pass the found location back to the calling class.
        /// </param>
        /// <param name="name">name to search for</param>
        public void Find(
            Action<string> locationAction,
            string name)
        {
            Task.Run(() =>
            {
                // Get the collection of all files.
                string[] subdirectoryEntries =
                    Directory.GetDirectories(
                        DataPath.RawDataPath);

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
                                    locationAction.Invoke(raw.Location);
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