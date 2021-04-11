namespace Asland.Interfaces.Model.IO.Data
{
    using System.Collections.Generic;
    using Asland.Model.IO.Data;

    /// <summary>
    /// Interface describing the class which manages the IO of the Data classes.
    /// </summary>
    public interface IDataManager
    {
        /// <summary>
        /// Gets all the beasties in the system.
        /// </summary>
        List<Beastie> Beasties { get; }

        /// <summary>
        /// Add a beastie to the collection.
        /// </summary>
        /// <param name="newBeastie">beastie to add</param>
        void AddBeastie(Beastie newBeastie);

        /// <summary>
        /// Find a specific <see cref="Beastie"/>.
        /// </summary>
        /// <param name="name">name of the beastie</param>
        /// <returns>found beastie</returns>
        Beastie FindBeastie(string name);

        /// <summary>
        /// Reset the data in the data manager.
        /// </summary>
        void Reset();
    }
}
