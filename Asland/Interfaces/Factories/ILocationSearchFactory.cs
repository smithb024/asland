namespace Asland.Interfaces.Factories
{
    /// <summary>
    /// Interface used to describe the object with manages search access to the locations.
    /// </summary>
    public interface ILocationSearchFactory
    {
        /// <summary>
        /// Find and return data for a specific location.
        /// </summary>
        /// <param name="name">name to search for</param>
        void Find(string name);
    }
}