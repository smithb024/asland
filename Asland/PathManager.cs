namespace Asland
{
    using Asland.Interfaces;
    using System.Collections.Generic;
    using System.IO;
    using System;

    /// <summary>
    /// The Manager class which manages the path data.
    /// </summary>
    public class PathManager : IPathManager
    {
        /// <summary>
        /// The name of the file which contains the data's base path.
        /// </summary>
        private const string PathFileName = ".\\aslandPath.txt";

        /// <summary>
        /// The location of all raw data files.
        /// </summary>
        private string basePath;

        /// <summary>
        /// Initialises a new instance of the <see cref="PathManager"/> class.
        /// </summary>
        /// <param name="logger">The program logger</param>
        public PathManager(
            IAsLogger logger)
        {
            try
            {
                List<string> fileContents = new List<string>();

                if (File.Exists(PathFileName))
                {
                    using (StreamReader reader = new StreamReader(PathFileName))
                    {
                        this.basePath = reader.ReadLine();
                        logger.WriteLine(
                            string.Format($"Base path read: {this.basePath}"));
                    }
                }

            }
            catch (Exception ex)
            {
                logger.WriteLine(
                    string.Format($"Error, failed to read {PathFileName}: {ex}"));
            }
        }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        public string BasePath => $"{this.basePath}";

        /// <summary>
        /// Gets the location of all beastie data files.
        /// </summary>
        public string BeastieDataPath => $"{this.basePath}\\beasties";

        /// <summary>
        /// Gets the location of all raw data files.
        /// </summary>
        public string RawDataPath => $"{this.basePath}\\raw";

        /// <summary>
        /// Gets the location of all image files.
        /// </summary>
        public string ImageDataPath => $"{this.basePath}\\images";

        /// <summary>
        /// Gets the location of the index file.
        /// </summary>
        public string IndexPath => $"{this.basePath}\\TestDataEntry.xml";
    }
}