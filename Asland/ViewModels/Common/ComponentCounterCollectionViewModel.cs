namespace Asland.ViewModels.Common
{
    using Asland.Interfaces.ViewModels.Common;
    using NynaeveLib.ViewModel;
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <summary>
    /// View model class which manages a single collection of <see cref="IComponentCounterViewModel"/>
    /// objects.
    /// </summary>
    public class ComponentCounterCollectionViewModel : ViewModelBase, IComponentCounterCollectionViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ComponentCounterCollectionViewModel"/> class.
        /// </summary>
        /// <param name="collectionName">collection name</param>
        public ComponentCounterCollectionViewModel(string collectionName)
        {
            this.Name = collectionName;
            this.Counters = new ObservableCollection<IComponentCounterViewModel>();
        }

        /// <summary>
        /// Gets the name of the collection
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the collection of <see cref="ComponentCounterViewModel"/> objects.
        /// </summary>
        public ObservableCollection<IComponentCounterViewModel> Counters { get; private set; }

        /// <summary>
        /// Gets the number of counters.
        /// </summary>
        public int Count => this.Counters.Count;

        /// <summary>
        /// Add one <paramref name="componentName"/>.
        /// If there is an existing <see cref="IComponentCounterViewModel"/> with the component name
        /// then one is added to that, otherwise an new counter is created.
        /// </summary>
        /// <param name="componentName"></param>
        public void AddOne(string componentName)
        {
            IComponentCounterViewModel foundComponent = null;

            if (this.Counters.Count > 0)
            {
                foundComponent =
                    this.Counters.FirstOrDefault(c => c.Name == componentName);
            }

            if (foundComponent != null)
            {
                foundComponent.AddOne();
            }
            else
            {
                IComponentCounterViewModel newComponent =
                    new ComponentCounterViewModel(
                        componentName);
                this.Counters.Add(newComponent);

                this.Counters =
                    new ObservableCollection<IComponentCounterViewModel>(
                        this.Counters.OrderBy(c => c.Name));
            }

            this.RaisePropertyChangedEvent(nameof(this.Count));
        }
    }
}