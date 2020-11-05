namespace Asland.Interfaces.ViewModels.Common
{
    /// <summary>
    /// View model interface, describes a single counter.
    /// </summary>
    public interface IComponentCounterViewModel
    {
        /// <summary>
        /// Gets the name of the counter.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the count value;
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Add one to the count.
        /// </summary>
        void AddOne();
    }
}
