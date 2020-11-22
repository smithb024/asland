namespace Asland.Interfaces.ViewModels.Body
{
    /// <summary>
    /// Interface for a view model which supports the data entry view. This is the top level view
    /// of data entry and should also support switching between the different sub views.
    /// </summary>
    public interface IDataEntryViewModel
    {
        /// <summary>
        /// Gets the view model for the workspace which is displayed.
        /// </summary>
        object CurrentWorkspace { get; }
    }
}
