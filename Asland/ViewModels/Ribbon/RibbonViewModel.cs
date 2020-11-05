namespace Asland.ViewModels.Ribbon
{
    using Asland.Common.Enums;
    using Asland.Common.Messages;
    using Asland.Interfaces.ViewModels.Ribbon;
    using GalaSoft.MvvmLight.Messaging;
    using NynaeveLib.Commands;
    using NynaeveLib.ViewModel;
    using System;
    using System.Windows.Input;

    /// <summary>
    /// View model describing the ribbon view.
    /// </summary>
    public class RibbonViewModel : ViewModelBase, IRibbonViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Ribbon"/> class.
        /// </summary>
        public RibbonViewModel()
        {
            this.DisplayConsistencyViewCommand =
                new CommonCommand(
                    this.DisplayConsistencyView);
            this.DisplayConfigurationViewCommand =
                new CommonCommand(
                    this.DisplayConfigurationView);
            this.DisplayDataEntryViewCommand =
                new CommonCommand(
                    this.DisplayDataEntryView);
        }

        /// <summary>
        /// Command used to display the consistency checker view.
        /// </summary>
        public ICommand DisplayConsistencyViewCommand { get; }

        /// <summary>
        /// Command used to display the configuration view.
        /// </summary>
        public ICommand DisplayConfigurationViewCommand { get; }

        /// <summary>
        /// Command used to display the data entry view.
        /// </summary>
        public ICommand DisplayDataEntryViewCommand { get; }

        /// <summary>
        /// Request that the Consistency Checker view is displayed.
        /// </summary>
        private void DisplayConsistencyView()
        {
            this.SemdMessage(
                    MainViews.Consistency);
        }

        /// <summary>
        /// Request that the Configuration view is displayed.
        /// </summary>
        private void DisplayConfigurationView()
        {
            this.SemdMessage(
                    MainViews.Configuration);
        }

        /// <summary>
        /// Request that the Data Entry view is displayed.
        /// </summary>
        private void DisplayDataEntryView()
        {
            this.SemdMessage(
                    MainViews.DataEntry);
        }

        /// <summary>
        /// Send a message to display a new view.
        /// </summary>
        /// <param name="view">view to display</param>
        private void SemdMessage(MainViews view)
        {
            MainViewMessage message =
                new MainViewMessage(
                    view);

            Messenger.Default.Send<MainViewMessage>(message);
        }
    }
}