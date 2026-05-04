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
        /// <param name="countLocation">
        /// The action which used to pass a location name back to the calling class. Every 
        /// location should be sent so that they can all be counted.
        /// </param>
        /// <param name="complete">
        /// The action which is used to indicate that the job has been completed.
        /// </param>
        /// <param name="name">name to search for</param>
        void Find(
            Action<RawObservationsString> beastieAction,
            Action<string> countLocation,
            Action complete,
            string name);
    }
}