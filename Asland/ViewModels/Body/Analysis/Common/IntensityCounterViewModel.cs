namespace Asland.ViewModels.Body.Analysis.Common
{
    using Asland.Common.Enums;
    using Asland.Interfaces.ViewModels.Body.Analysis.Common;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// View model which counts a single instensity.
    /// </summary>
    public class IntensityCounterViewModel : ViewModelBase, IIntensityCounterViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="IntensityCounterViewModel"/> class.
        /// </summary>
        /// <param name="name">The name of the intensity</param>
        public IntensityCounterViewModel(
            ObservationIntensity name) 
        { 
            this.Name = name;
            this.Count = 1;
        }

        /// <summary>
        /// Gets the <see cref="ObservationIntensity"/> which is the subject of this view model.
        /// </summary>
        public ObservationIntensity Name { get; }

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
        public void CountIntensity()
        {
            ++this.Count;
            this.OnPropertyChanged(nameof(this.Count));
        }
    }
}
