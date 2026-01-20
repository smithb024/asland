namespace Asland.ViewModels.Body.Analysis
{
    using Asland.Interfaces.Model.IO.Data;
    using Asland.Interfaces.ViewModels.Body.Analysis;
    using Asland.Interfaces.ViewModels.Body.Analysis.Beasties;
    using Asland.Model.IO.Data;
    using Asland.ViewModels.Body.Analysis.Beasties;
    using NynaeveLib.ViewModel;
    using System.Collections.ObjectModel;

    /// <summary>
    /// View Model which supports the beastie view on the analysis tab.
    /// </summary>
    public class BeastieViewModel : ViewModelBase, IBeastieViewModel
    {
        /// <summary>
        /// The collection of all known beasties.
        /// </summary>
        private ObservableCollection<string> beasties;

        /// <summary>
        /// The index of the currently selected beastie.
        /// </summary>
        private int selectedBeastieIndex;

        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieViewModel"/> class
        /// </summary>
        /// <param name="dataManager">data manager</param>
        public BeastieViewModel(
            IDataManager dataManager) 
        {
            this.beasties = new ObservableCollection<string>();
            this.selectedBeastieIndex = -1;
            this.Summary = new BeastieSummaryViewModel();

            foreach (Beastie beastie in dataManager.Beasties)
            {
                this.beasties.Add(beastie.Name);
            }
        }

        /// <summary>
        /// Gets a collection of beastie.
        /// </summary>
        public ObservableCollection<string> Beasties => this.beasties;

        /// <summary>
        /// Gets or sets the index of the currently selected beastie.
        /// </summary>
        public int BeastieIndex 
        { 
            get => this.selectedBeastieIndex;
            set
            {
                if (this.selectedBeastieIndex == value)
                {
                    return;
                }

                this.selectedBeastieIndex = value;
                this.OnPropertyChanged(nameof(this.BeastieIndex));
            }
        }

        /// <summary>
        /// Gets the summary for the selected beastie.
        /// </summary>
        public IBeastieSummaryViewModel Summary { get; }
    }
}