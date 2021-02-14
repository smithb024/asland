namespace Asland.Interfaces.Factories
{
    using System.Collections.Generic;

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
    }
}