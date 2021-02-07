namespace Asland.Interfaces.ViewModels.Body
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using NynaeveLib.Commands;

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
        /// Gets a selection of commands which are used to choose a page to display.
        /// </summary>
        List<IIndexCommand<string>> PageSelector { get; }

        /// <summary>
        /// Command used to save the current event.
        /// </summary>
        ICommand SaveCommand { get; }

        /// <summary>
        /// Command used to load an existing event.
        /// </summary>
        ICommand LoadCommand { get; }

        /// <summary>
        /// Gets a value which indicates whether the current event is being edited.
        /// </summary>
        bool IsEditing { get; }

        /// <summary>
        /// Gets a string which describes the editing status.
        /// </summary>
        string EditingText { get; }
    }
}