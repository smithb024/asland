namespace Asland.Interfaces.ViewModels.Common
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// View model interface describes a collection of component counters.
    /// </summary>
    public interface IComponentCounterCollectionViewModel
    { /// <summary>
      /// Gets the name of the collection
      /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the collection of <see cref="ComponentCounterViewModel"/> objects.
        /// </summary>
        ObservableCollection<IComponentCounterViewModel> Counters { get; }

        int Count { get; }

        /// <summary>
        /// Add one <paramref name="componentName"/>.
        /// If there is an existing <see cref="ComponentCounterViewModel"/> with the component name
        /// then one is added to that, otherwise an new counter is created.
        /// </summary>
        /// <param name="componentName"></param>
        void AddOne(string componentName);
    }
}