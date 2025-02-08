namespace Asland.ViewModels.Body.Analysis
{
    using Asland.Interfaces.ViewModels.Body.Analysis;
    using Asland.Interfaces.ViewModels.Body.Analysis.Year;
    using Asland.ViewModels.Body.Analysis.Year;
    using NynaeveLib.ViewModel;
    using System.Collections.ObjectModel;

    /// <summary>
    /// View Model which supports the year view on the analysis tab.
    /// </summary>
    public class YearViewModel : ViewModelBase, IYearViewModel
    {
        /// <summary>
        /// The index of the currently selected year.
        /// </summary>
        private int selectedYearIndex;

        /// <summary>
        /// Initialises a new instance of the <see cref="YearViewModel"/> class.
        /// </summary>
        public YearViewModel() 
        {
            this.Summary =
                new YearSummaryViewModel();

            this.Years = 
                new ObservableCollection<string>()
                {
                    "1",
                    "2"
                };
            this.selectedYearIndex = -1;
        }

        /// <summary>
        /// Gets a collection of years.
        /// </summary>
        public ObservableCollection<string> Years { get; }

        /// <summary>
        /// Gets or sets the index of the currently selected year.
        /// </summary>
        public int YearIndex
        {
            get => this.selectedYearIndex;
            set
            {
                if (this.selectedYearIndex == value)
                {
                    return;
                }

                this.selectedYearIndex = value;
                this.OnPropertyChanged(nameof(this.YearIndex));
            }
        }

        /// <summary>
        /// Gets the summary for the selected location.
        /// </summary>
        public IYearSummaryViewModel Summary { get; }
    }
}