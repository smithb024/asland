namespace Asland.ViewModels.Body.Analysis.Common
{
    using Asland.Interfaces.ViewModels.Body.Analysis.Common;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// A view model to describe a single location on the analysis view.
    /// </summary>
    public class LocationAnalysisIconViewModel : ViewModelBase, ILocationAnalysisIconViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieAnalysisIconViewModel"/> class.
        /// </summary>
        /// <param name="name">the name of the location</param>
        public LocationAnalysisIconViewModel(
            string name)
        {
            this.Name = name;
            this.Count = 0;
        }

        /// <summary>
        /// Gets the name of the location.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the total number of times this location has been counted.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Count the location.
        /// </summary>
        public void CountLocation()
        {
            ++this.Count;
            this.OnPropertyChanged(nameof(this.Count));
        }
    }
}