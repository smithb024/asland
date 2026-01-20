namespace Asland.ViewModels.Body.Analysis.Beasties
{
    using Asland.Interfaces.ViewModels.Body.Analysis.Beasties;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// View model which supports the summary view on the beastie analysis.
    /// </summary>
    public class BeastieSummaryViewModel : ViewModelBase, IBeastieSummaryViewModel
    {
        /// <summary>
        /// The name of the current beastie.
        /// </summary>
        private string name;

        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieSummaryViewModel"/> class.
        /// </summary>
        public BeastieSummaryViewModel() 
        {
            this.name = string.Empty;
        }

        /// <summary>
        /// Gets the name of the current beastie.
        /// </summary>
        public string Name
        {
            get => this.name;
            private set
            {
                if (this.name == value)
                {
                    return;
                }

                this.name = value;
                this.OnPropertyChanged(nameof(this.Name));
            }
        }

        /// <summary>
        /// Sets a new beastie for which to display a new set of summary data.
        /// </summary>
        /// <param name="name">The name of the new beastie</param>
        public void SetNewBeastie(string name)
        {
            this.Name = name;
        }
    }
}
