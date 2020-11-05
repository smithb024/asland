namespace Asland.ViewModels.Common
{
    using Asland.Interfaces.ViewModels.Common;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// View model for a component counter.
    /// </summary>
    public class ComponentCounterViewModel : ViewModelBase, IComponentCounterViewModel
    {
        /// <summary>
        /// Component counter.
        /// </summary>
        private int counter;

        /// <summary>
        /// Initialises a new instance of the <see cref="ComponentCounterViewModel"/> class.
        /// </summary>
        /// <param name="name">name of the component</param>
        /// <param name="initialCount">initial count, defaukt is one.</param>
        public ComponentCounterViewModel(
            string name,
            int initialCount = 1)
        {
            this.Name = name;
            this.counter = initialCount;
        }

        /// <summary>
        /// Gets the name of the counter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the count value;
        /// </summary>
        public int Count
        {
            get
            {
                return this.counter;
            }

            private set
            {
                if (this.counter != value)
                {
                    this.counter = value;
                    this.RaisePropertyChangedEvent(nameof(this.Count));
                }
            }
        }

        /// <summary>
        /// Add one to the count.
        /// </summary>
        public void AddOne()
        {
            ++this.Count;
        }
    }
}