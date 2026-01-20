namespace Asland.Interfaces.Factories
{
    using Asland.Model.IO;
    using Asland.Model.IO.Data;
    using System;
    using System.Collections.Generic;

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

        /// <summary>
        /// Find and return data for a specific beastie.
        /// </summary>
        /// <remarks>
        /// It returns the data by calling <paramref name="beastieAction"/> for each observation 
        /// containing the named beastie.
        /// </remarks>
        /// <param name="beastieAction">
        /// The action which is used to pass the found raw data back to the calling class.
        /// </param>
        /// <param name="name">name to search for</param>
        void Find(
            Action<RawObservationsString> beastieAction,
            string name);
    }
}