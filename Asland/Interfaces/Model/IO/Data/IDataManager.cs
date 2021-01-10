namespace Asland.Interfaces.Model.IO.Data
{
    using Asland.Model.IO.Data;

    /// <summary>
    /// Interface describing the class which manages the IO of the Data classes.
    /// </summary>
    public interface IDataManager
    {
        /// <summary>
        /// Create an empty beastie file with the given name.
        /// </summary>
        /// <param name="name">name of the beastie</param>
        void CreateEmptyBeastieFile(string name);

        /// <summary>
        /// Indicates whether there is a data file corresponding to the name.
        /// </summary>
        /// <param name="name">name to check</param>
        /// <returns>value indicating whether the file exists</returns>
        bool FileExists(string name);

        /// <summary>
        /// Save the beastie file.
        /// </summary>
        /// <param name="beastieFile">serialisable object to save</param>
        void Save(Beastie beastieFile);
    }
}
