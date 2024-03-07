namespace Asland.Interfaces.ViewModels.Body.Analysis.Common
{
    using Asland.Interfaces.ViewModels.Body.Common;

    /// <summary>
    /// This interface extends the beastie icon and presents analysis information.
    /// </summary>
    public interface IBeastieAnalysisIconViewModel : IBeastieIconBaseViewModel
    {
        /// <summary>
        /// Gets the total number of times this beastie has been counted.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets the total number of times this beastie has been assessed.
        /// </summary>
        int Total { get; }

        /// <summary>
        /// Gets the totla number of times this beastie has been counted as a percentage of the
        /// number of times it has been assessed. 
        /// </summary>
        double Percentage { get; }

        /// <summary>
        /// Gets the <see cref="Percentage"/> as a string.
        /// </summary>
        string PercentageString { get; }

        /// <summary>
        /// Count the beastie.
        /// </summary>
        void CountBeastie();

        /// <summary>
        /// Increase the assessment count. This should always be called, whether the beastie is 
        /// counted or not.
        /// </summary>
        void AssessBeastie();
    }
}