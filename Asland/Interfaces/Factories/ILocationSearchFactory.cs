namespace Asland.Interfaces.Factories
{
    using System;

    /// <summary>
    /// Interface used to describe the object with manages search access to the locations.
    /// </summary>
    public interface ILocationSearchFactory
    {
        /// <summary>
        /// Find and return data for a specific location.
        /// </summary>
        /// <param name="locationAction">
        /// The action which is used to pass the found location back to the calling class.
        /// </param>
        /// <param name="name">name to search for</param>
        void Find(
            Action<string> locationAction,
            string name);
    }
}