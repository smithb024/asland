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
        private string pathFileName = ".\\aslandPath.txt";

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

                if (File.Exists(pathFileName))
                {
                    using (StreamReader reader = new StreamReader(pathFileName))
                    {
                        string currentLine = reader.ReadLine();
                    }
                }

            }
            catch (Exception ex)
            {
                logger.WriteLine(
                    string.Format("Error, failed to read {0}: {1}", pathFileName, ex.ToString()));
            }
        }
    }
}