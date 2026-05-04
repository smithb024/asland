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
            this.Total = 0;
            this.Percentage = 0;
            this.PercentageString = "0.00%";
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
        /// Gets the total number of times this location has been assessed.
        /// </summary>
        public int Total { get; private set; }

        /// <summary>
        /// Gets the totla number of times this location has been counted as a percentage of the
        /// number of times it has been assessed. 
        /// </summary>
        public double Percentage { get; private set; }

        /// <summary>
        /// Gets the <see cref="Percentage"/> as a string.
        /// </summary>
        public string PercentageString { get; private set; }

        /// <summary>
        /// Count the location.
        /// </summary>
        public void CountLocation()
        {
            ++this.Count;
            this.OnPropertyChanged(nameof(this.Count));
        }

        /// <summary>
        /// Set the total number of times this location has been visited.
        /// </summary>
        /// <param name="total">The total number of times.</param>
        public void SetTotal(int total)
        {
            this.Total = total;
            this.OnPropertyChanged(nameof(this.Total));
            this.CalculatePercentage();
        }

        /// <summary>
        /// Calculate the percentage properties.
        /// </summary>
        private void CalculatePercentage()
        {
            if (this.Total == 0)
            {
                this.Percentage = 0;
                this.PercentageString = "0.00%";
            }
            else
            {
                this.Percentage = (double)this.Count / (double)this.Total * (double)100;
                this.PercentageString = $"{string.Format("{0:0.00}", this.Percentage)}%";
            }


            this.OnPropertyChanged(nameof(this.Percentage));
            this.OnPropertyChanged(nameof(this.PercentageString));
        }
    }
}