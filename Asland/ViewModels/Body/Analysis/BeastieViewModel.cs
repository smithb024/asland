namespace Asland.ViewModels.Body.Analysis
{
    using Asland.Interfaces.ViewModels.Body.Analysis;
    using Asland.Interfaces.ViewModels.Body.Analysis.Beasties;
    using Asland.ViewModels.Body.Analysis.Beasties;
    using NynaeveLib.ViewModel;
    using System.Collections.ObjectModel;

    /// <summary>
    /// View Model which supports the beastie view on the analysis tab.
    /// </summary>
    public class BeastieViewModel : ViewModelBase, IBeastieViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieViewModel"/> class
        /// </summary>
        public BeastieViewModel() 
        {
            this.Beasties = new ObservableCollection<string>();
            this.BeastieIndex = 0;
            this.Summary = new BeastieSummaryViewModel();
        }

        /// <summary>
        /// Gets a collection of beastie.
        /// </summary>
        public ObservableCollection<string> Beasties { get; }

        /// <summary>
        /// Gets or sets the index of the currently selected beastie.
        /// </summary>
        public int BeastieIndex { get; set; }

        /// <summary>
        /// Gets the summary for the selected beastie.
        /// </summary>
        public IBeastieSummaryViewModel Summary { get; }
    }
}