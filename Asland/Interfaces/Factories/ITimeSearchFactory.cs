namespace Asland.Interfaces.Factories
{
    using Asland.Model.IO;
    using System;

    /// <summary>
    /// Interface used to describe the object with manages search access to a time period.
    /// </summary>
    public interface ITimeSearchFactory
    {
        /// <summary>
        /// Find and return data for a specific year.
        /// </summary>
        /// <param name="yearAction">
        /// The action which is used to pass the found data back to the calling class.
        /// </param>
        /// <param name="year">year to search for</param>
        void Find(
            Action<RawObservationsString> yearAction,
            string year);
    }
}