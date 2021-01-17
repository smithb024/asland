namespace Asland.Model.IO.Data
{
    using System;
    using System.IO;
    using Factories.IO;
    using Interfaces.Model.IO.Data;

    /// <summary>
    /// Class which manages the IO of the Data classes.
    /// </summary>
    public class DataManager : IDataManager
    {
        /// <summary>
        /// Create an empty beastie file with the given name.
        /// </summary>
        /// <param name="name">name of the beastie</param>
        public void CreateEmptyBeastieFile(string name)
        {
            Beastie newFile =
                new Beastie()
                {
                    Name = name,
                    DisplayName = name,
                    LatinName = string.Empty,
                    Image = string.Empty,
                    Size = 0,
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
        }

        /// <summary>
        /// Indicates whether there is a data file corresponding to the name.
        /// </summary>
        /// <param name="name">name to check</param>
        /// <returns>value indicating whether the file exists</returns>
        public bool FileExists(string name)
        {
            try
            {
                return File.Exists($"{DataPath.BeastieDataPath}\\{name}.xml");
            }
            catch (Exception ex)
            {
                // TODO #26
                return false;
            }
        }

        /// <summary>
        /// Save the beastie file.
        /// </summary>
        /// <param name="beastieFile">serialisable object to save</param>
        public void Save(Beastie beastieFile)
        {
            if (string.IsNullOrWhiteSpace(beastieFile.Name))
            {
                // TODO #27 Error saving file - Need to note this.
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
                // TODO #27 Error saving file - Need to note this.
                string error = ex.ToString();
            }
        }
    }
}