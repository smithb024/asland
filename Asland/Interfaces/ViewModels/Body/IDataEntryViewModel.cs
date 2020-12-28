namespace Asland.Interfaces.ViewModels.Body
{
    using System.Windows.Input;
    using Asland.Common.Enums;
    using Interfaces.ViewModels.Common;

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

        /// <summary>
        /// Command used to save the current event.
        /// </summary>
        ICommand SaveCommand { get; }

        /// <summary>
        /// Command used to load an existing event.
        /// </summary>
        ICommand LoadCommand { get; }
    }
}