namespace Asland.ViewModels.Body.Analysis.Common
{
    using Asland.Common.Enums;
    using Asland.Interfaces.ViewModels.Body.Analysis.Common;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// View model which counts a single string.
    /// </summary>
    public class StringCounterViewModel : ViewModelBase, IStringCounterViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="StringCounterViewModel"/> class.
        /// </summary>
        /// <param name="name">The name of the object being counted</param>
        public StringCounterViewModel(
            string name) 
        { 
            this.Name = name;
            this.Count = 1;
        }

        /// <summary>
        /// Gets the string which is the subject of this view model.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the <see cref="Name"/> as a string.
        /// </summary>
        public string Description => this.Name;

        /// <summary>
        /// Gets the total number of occurances of <see cref="Name"/>.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Add one to the <see cref="Count"/>.
        /// </summary>
        public void CountOne()
        {
            ++this.Count;
            this.OnPropertyChanged(nameof(this.Count));
        }
    }
}
