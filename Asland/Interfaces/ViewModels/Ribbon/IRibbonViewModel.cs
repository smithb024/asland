namespace Asland.Interfaces.ViewModels.Ribbon
{
    using System.Windows.Input;

    /// <summary>
    /// Interface which describes the ribbon view model.
    /// </summary>
    public interface IRibbonViewModel
    {
        /// <summary>
        /// Command used to display the consistency checker view.
        /// </summary>
        ICommand DisplayConsistencyViewCommand { get; }

        /// <summary>
        /// Command used to display the configuration view.
        /// </summary>
        ICommand DisplayConfigurationViewCommand { get; }

        /// <summary>
        /// Command used to display the data entry view.
        /// </summary>
        ICommand DisplayDataEntryViewCommand { get; }
    }
}