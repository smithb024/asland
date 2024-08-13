namespace Asland.ViewModels.Body.Analysis.Common
{
    using Asland.Common.Enums;
    using Asland.Interfaces.ViewModels.Body.Analysis.Common;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// View model which counts a single habitat.
    /// </summary>
    public class HabitatCounterViewModel : ViewModelBase, IHabitatCounterViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="HabitatCounterViewModel"/> class.
        /// </summary>
        /// <param name="name">The name of the habitat</param>
        public HabitatCounterViewModel(
            ObservationHabitat name) 
        { 
            this.Name = name;
            this.Count = 1;
        }

        /// <summary>
        /// Gets the <see cref="ObservationHabitat"/> which is the subject of this view model.
        /// </summary>
        public ObservationHabitat Name { get; }

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
        public void CountHabitat()
        {
            ++this.Count;
            this.RaisePropertyChangedEvent(nameof(this.Count));
        }
    }
}
