namespace Asland.Interfaces.ViewModels.Body.Analysis.Beasties
{
    /// <summary>
    /// Interface which supports the summary view on the beastie analysis page.
    /// </summary>
    public interface IBeastieSummaryViewModel
    {
        /// <summary>
        /// Gets the name of the current beastie.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Sets a new beastie for which to display a new set of summary data.
        /// </summary>
        /// <param name="name">The name of the new beastie</param>
        void SetNewBeastie(string name);
    }
}
