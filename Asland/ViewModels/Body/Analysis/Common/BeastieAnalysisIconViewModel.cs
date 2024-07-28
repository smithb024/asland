namespace Asland.ViewModels.Body.Analysis.Common
{
    using Asland.Common.Enums;
    using Asland.Interfaces;
    using Asland.Interfaces.ViewModels.Body.Analysis.Common;
    using Asland.ViewModels.Body.Common;

    /// <summary>
    /// A view model to describe a single beastie on the analysis view.
    /// </summary>
    public class BeastieAnalysisIconViewModel : BeastieIconBaseViewModel, IBeastieAnalysisIconViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieAnalysisIconViewModel"/> class.
        /// </summary>
        /// <param name="pathManager">the path manager</param>
        /// <param name="name">the name of the beastie</param>
        /// <param name="commonName">the display name of the beastie</param>
        /// <param name="latinName">the latin name of the beastie</param>
        /// <param name="imagePath">the path to the beastie's image</param>
        /// <param name="presence">the presence of the beastie in the locality</param>
        public BeastieAnalysisIconViewModel(
            IPathManager pathManager,
            string name,
            string commonName,
            string latinName,
            string imagePath,
            Presence presence)
            : base(
                  pathManager,
                  name,
                  commonName,
                  latinName,
                  imagePath,
                  presence)
        {
            this.Count = 0;
            this.Total = 0;
            this.PercentageString = "0.00%";
        }

        /// <summary>
        /// Gets the total number of times this beastie has been counted.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets the total number of times this beastie has been assessed.
        /// </summary>
        public int Total { get; private set; }

        /// <summary>
        /// Gets the totla number of times this beastie has been counted as a percentage of the
        /// number of times it has been assessed. 
        /// </summary>
        public double Percentage { get; private set; }

        /// <summary>
        /// Gets the <see cref="Percentage"/> as a string.
        /// </summary>
        public string PercentageString { get; private set; }

        /// <summary>
        /// Count the beastie.
        /// </summary>
        public void CountBeastie()
        {
            ++this.Count;
            this.RaisePropertyChangedEvent(nameof(this.Count));
            this.CalculatePercentage();
        }

        /// <summary>
        /// Increase the assessment count. This should always be called, whether the beastie is 
        /// counted or not.
        /// </summary>
        public void AssessBeastie()
        {
            ++this.Total;
            this.RaisePropertyChangedEvent(nameof(this.Total));
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


            this.RaisePropertyChangedEvent(nameof(this.Percentage));
            this.RaisePropertyChangedEvent(nameof(this.PercentageString));
        }
    }
}