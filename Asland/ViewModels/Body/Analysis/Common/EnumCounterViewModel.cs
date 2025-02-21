namespace Asland.ViewModels.Body.Analysis.Common
{
    using Asland.Interfaces.ViewModels.Body.Analysis.Common;
    using NynaeveLib.ViewModel;
    using System;

    public class EnumCounterViewModel<T> : ViewModelBase, IEnumCounterViewModel<T> where T : Enum
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EnumCounterViewModel"/> class.
        /// </summary>
        /// <param name="name">The name of the habitat</param>
        public EnumCounterViewModel(
            T name)
        {
            this.Name = name;
            this.Count = 1;
        }

        /// <summary>
        /// Gets the <see cref="T"/> which is the subject of this view model.
        /// </summary>
        public T Name { get; }

        /// <summary>
        /// Gets the <see cref="Name"/> as a string.
        /// </summary>
        public string Description => this.Name.ToString();

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
