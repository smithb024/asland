namespace Asland.Interfaces.Model.IO.Data
{
    using Asland.Model.IO.Data;

    /// <summary>
    /// Interface describing the class which manages the IO of the Data classes.
    /// </summary>
    public interface IDataManager
    {
        /// <summary>
        /// Add a beastie to the collection.
        /// </summary>
        /// <param name="newBeastie">beastie to add</param>
        void AddBeastie(Beastie newBeastie);

        /// <summary>
        /// Reset the data in the data manager.
        /// </summary>
        void Reset();
    }
}
