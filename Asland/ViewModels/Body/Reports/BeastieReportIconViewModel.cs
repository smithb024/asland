namespace Asland.ViewModels.Body.Reports
{
    using Asland.Common.Enums;
    using Asland.Interfaces;
    using Asland.Interfaces.ViewModels.Body.Reports;
    using Asland.ViewModels.Body.Common;

    /// <summary>
    /// View model class for a report beastie icon.
    /// </summary>
    public class BeastieReportIconViewModel : BeastieIconBaseViewModel, IBeastieReportIconViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieReportIconViewModel"/> class
        /// </summary>
        /// <param name="pathManager">the path manager</param>
        /// <param name="commonName">the name of the beastie</param>
        /// <param name="latinName">the latin name of the beastie</param>
        /// <param name="imagePath">the path to the beastie's image</param>
        /// <param name="presence">the presence of the beastie in the locality</param>
        public BeastieReportIconViewModel(
            IPathManager pathManager,
            string commonName,
            string latinName,
            string imagePath,
            Presence presence) 
            : base(
                  pathManager,
                  commonName,
                  latinName,
                  imagePath,
                  presence)
        {
        }
    }
}