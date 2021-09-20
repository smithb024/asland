namespace Asland.Factories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Asland.Common.Messages;
    using Asland.Model.IO.Data;
    using Factories.IO;
    using GalaSoft.MvvmLight.Messaging;
    using Interfaces;
    using Interfaces.Factories;
    using Interfaces.Model.IO.Data;

    /// <summary>
    /// Factory class which manages the Beastie Data Files.
    /// </summary>
    public class BeastieDataFileFactory : IBeastieDataFileFactory
    {
        /// <summary>
        /// Logger object.
        /// </summary>
        private IAsLogger logger;

        /// <summary>
        ///  The data manager.
        /// </summary>
        private IDataManager dataManager;

        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieDataFileFactory"/> class.
        /// </summary>
        /// <param name="dataManager">The data manager</param>
        public BeastieDataFileFactory(
            IAsLogger logger,
            IDataManager dataManager)
        {
            this.logger = logger;
            this.dataManager = dataManager;
            this.LoadAll();
        }

        /// <summary>
        /// Goes through a list of names and ensures that each on has a data file.
        /// </summary>
        /// <param name="names">collection of names to check</param>
        /// <param name="dataManager">the data IO manager</param>
        public void CheckFiles(
          List<string> names)
        {
            foreach(string name in names)
            {
               if (!this.FileExists(name))
                {
                    this.CreateEmptyBeastieFile(name);
                }
            }
        }

        /// <summary>
        /// Create a beastie file for <paramref name="name"/> and set it up with a set of default 
        /// values. 
        /// </summary>
        /// <param name="name">The name of the new beastie</param>
        private void CreateEmptyBeastieFile(string name)
        {
            Beastie newFile =
                new Beastie()
                {
                    Name = name,
                    DisplayName = name,
                    LatinName = string.Empty,
                    Image = string.Empty,
                    ThumbnailImage = string.Empty,
                    Size = 0,
                    Wingspan = 0,
                    Classification = string.Empty,
                    ClassLatin = string.Empty,
                    Order = string.Empty,
                    OrderLatin = string.Empty,
                    Family = string.Empty,
                    FamilyLatin = string.Empty,
                    SubFamily = "N/A",
                    SubFamilyLatin = "N/A",
                    Genus = string.Empty,
                    GenusLatin = string.Empty
                };

            this.Save(newFile);
            this.dataManager.AddBeastie(newFile);
        }

        /// <summary>
        /// Save the beastie file.
        /// </summary>
        /// <param name="beastieFile">serialisable object to save</param>
        public void Save(Beastie beastieFile)
        {
            if (string.IsNullOrWhiteSpace(beastieFile.Name))
            {
                this.logger.WriteLine(
                    $"Error saving beastie file, filename is null or empty");
                return;
            }

            string path = $"{DataPath.BeastieDataPath}";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            try
            {
                XmlFileIo.WriteXml(
                    beastieFile,
                    $"{path}\\{beastieFile.Name}.xml");
            }
            catch (Exception ex)
            {
                this.logger.WriteLine(
                    $"Error saving {beastieFile.Name}: {ex}");
            }
        }

        /// <summary>
        /// Indicates whether there is a data file corresponding to the name.
        /// </summary>
        /// <param name="name">name to check</param>
        /// <returns>value indicating whether the file exists</returns>
        private bool FileExists(string name)
        {
            try
            {
                return File.Exists($"{DataPath.BeastieDataPath}\\{name}.xml");
            }
            catch (Exception ex)
            {
                this.logger.WriteLine(
                    $"Error finding {name}: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Load all beasties.
        /// </summary>
        private void LoadAll()
        {
            string path = $"{DataPath.BeastieDataPath}";
            string[] xmlFiles;

            if (!Directory.Exists(path))
            {
                return;
            }

            try
            {
                xmlFiles =
                    Directory.GetFiles(
                        path,
                        "*.xml");
            }
            catch (Exception ex)
            {
                xmlFiles = new string[0];

                this.logger.WriteLine(
                    $"Error loading all beastie files: {ex}");
            }

            foreach (string file in xmlFiles)
            {
                this.LoadFile(file);
            }
        }

        /// <summary>
        /// Load a file and store it in the Data Manager
        /// </summary>
        /// <param name="path">path of the file to load</param>
        private void LoadFile(string path)
        {
            try
            {
                Beastie beastie =
                    XmlFileIo.ReadXml<Beastie>(
                        path);

                this.dataManager.AddBeastie(beastie);
            }
            catch (Exception ex)
            {
                AppStatusMessage message =
                    new AppStatusMessage(
                        $"Error loading {path}");
                Messenger.Default.Send(message);
                
                this.logger.WriteLine(
                    $"Error loading {path}: {ex}");
            }
        }
    }
}
