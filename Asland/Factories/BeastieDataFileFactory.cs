namespace Asland.Factories
{
    using System.Collections.Generic;
    using Interfaces.Model.IO.Data;

    /// <summary>
    /// Factory class which manages the Beastie Data Files.
    /// </summary>
    public static class BeastieDataFileFactory
    {
        /// <summary>
        /// Goes through a list of names and ensures that each on has a data file.
        /// </summary>
        /// <param name="names">collection of names to check</param>
        /// <param name="dataManager">the data IO manager</param>
        public static void CheckFiles(
            List<string> names,
            IDataManager dataManager)
        {
            foreach(string name in names)
            {
               if (!dataManager.FileExists(name))
                {
                    dataManager.CreateEmptyBeastieFile(name);
                }
            }
        }
    }
}
