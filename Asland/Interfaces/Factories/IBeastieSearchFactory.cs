namespace Asland.Interfaces.Factories
{
    using System.Collections.Generic;
    using Asland.Model.IO.Data;

    /// <summary>
    /// Interface used to describe the object with manages search access to the beasties. 
    /// </summary>
    public interface IBeastieSearchFactory
    {
        /// <summary>
        /// Get a list of all known beasties.
        /// </summary>
        /// <returns>beastie names</returns>
        Dictionary<string, string> FindAllNames();

        /// <summary>
        /// Find and return a specific beastie
        /// </summary>
        /// <param name="name">name to search for</param>
        /// <returns>found beastie</returns>
        Beastie Find(string name); 
    }
}