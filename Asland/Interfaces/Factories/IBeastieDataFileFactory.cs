namespace Asland.Interfaces.Factories
{
    using System.Collections.Generic;
    using Asland.Model.IO.Data;

    /// <summary>
    /// Interface describing the factory which manages the beastie data files.
    /// </summary>
    public interface IBeastieDataFileFactory
    {
        /// <summary>
        /// Goes through a list of names and ensures that each on has a data file.
        /// </summary>
        /// <param name="names">collection of names to check</param>
        void CheckFiles(
            List<string> names);

        /// <summary>
        /// Save the beastie file.
        /// </summary>
        /// <param name="beastieFile">serialisable object to save</param>
        void Save(Beastie beastieFile);
    }
}