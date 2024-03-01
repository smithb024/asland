namespace Asland.ViewModels.Body.Analysis.Common
{
    using System;
    using System.Security.AccessControl;
    using Asland.Common.Enums;
    using Asland.Interfaces.ViewModels.Body.Analysis.Common;
    using Asland.ViewModels.Body.Common;
    using NynaeveLib.ViewModel;

    public class BeastieAnalysisIconViewModel : BeastieIconBaseViewModel, IBeastieAnalysisIconViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieAnalysisIconViewModel"/> class.
        /// </summary>
        /// <param name="commonName">the name of the beastie</param>
        /// <param name="latinName">the latin name of the beastie</param>
        /// <param name="imagePath">the path to the beastie's image</param>
        /// <param name="presence">the presence of the beastie in the locality</param>
        public BeastieAnalysisIconViewModel(
            string commonName,
            string latinName,
            string imagePath,
            Presence presence)
            : base(
                  commonName,
                  latinName,
                  imagePath,
                  presence)
        {
            this.Count = 0;
            this.Total = 0;
        }

        /// <summary>
        /// Gets the total number of times this beastie has been counted.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Gets the total number of times this beastie has been assessed.
        /// </summary>
        public int Total { get; }

        /// <summary>
        /// Gets the totla number of times this beastie has been counted as a percentage of the
        /// number of times it has been assessed. 
        /// </summary>
        public double Percentage
        {
            get
            {
                if (this.Total == 0)
                {
                    return 0;
                }

                return this.Count / this.Total;
            }
        }

        /// <summary>
        /// Gets the <see cref="Percentage"/> as a string.
        /// </summary>
        public string PercentageString => string.Format("{0:0.00}", this.Percentage);

        /// <summary>
        /// Count the beastie.
        /// </summary>
        public void CountBeastie()
        {

        }

        /// <summary>
        /// Increase the assessment count. This should always be called, whether the beastie is 
        /// counted or not.
        /// </summary>
        public void AssessBeastie()
        {

        }
    }
}