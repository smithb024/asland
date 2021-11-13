﻿namespace Asland.ViewModels.Ribbon
{
    using System.Collections.Generic;
    using Asland.Common.Enums;
    using Asland.Common.Messages;
    using Asland.Interfaces.ViewModels.Body.DataEntry;
    using Asland.Interfaces.ViewModels.Ribbon;
    using Asland.ViewModels.Body.DataEntry;
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
            this.PageSelector = new List<IPageSelector>();

            IPageSelector dataEntry =
                new PageSelector(
                  "Data Entry",
                  this.DisplayDataEntryView);
            IPageSelector configurationEntry =
                new PageSelector(
                  "Configuration",
                  this.DisplayConfigurationView);
            IPageSelector consistencyEntry =
                new PageSelector(
                  "Consistency",
                  this.DisplayConsistencyView);

            this.PageSelector.Add(dataEntry);
            this.PageSelector.Add(configurationEntry);
            this.PageSelector.Add(consistencyEntry);
        }

        /// <summary>
        /// Gets a selection of commands which are used to choose a page to display.
        /// </summary>
        public List<IPageSelector> PageSelector { get; }

        /// <summary>
        /// Request that the Consistency Checker view is displayed.
        /// </summary>
        /// <param name="newTabName">
        /// Name of the tab to display.
        /// </param>
        private void DisplayConsistencyView(string newTabName)
        {
            this.SendMessage(
                    MainViews.Consistency);
            this.NewTabDisplayed(newTabName);
        }

        /// <summary>
        /// Request that the Configuration view is displayed.
        /// </summary>
        /// <param name="newTabName">
        /// Name of the tab to display.
        /// </param>
        private void DisplayConfigurationView(string newTabName)
        {
            this.SendMessage(
                    MainViews.Configuration);
            this.NewTabDisplayed(newTabName);
        }

        /// <summary>
        /// Request that the Data Entry view is displayed.
        /// </summary>
        /// <param name="newTabName">
        /// Name of the tab to display.
        /// </param>
        private void DisplayDataEntryView(string newTabName)
        {
            this.SendMessage(
                    MainViews.DataEntry);
            this.NewTabDisplayed(newTabName);
        }

        /// <summary>
        /// Send a message to display a new view.
        /// </summary>
        /// <param name="view">view to display</param>
        private void SendMessage(MainViews view)
        {
            MainViewMessage message =
                new MainViewMessage(
                    view);

            Messenger.Default.Send<MainViewMessage>(message);
        }

        /// <summary>
        /// Update the selected icons on the tabs.
        /// </summary>
        /// <param name="newTabName"></param>
        private void NewTabDisplayed(string newTabName)
        {
            foreach (IPageSelector selector in this.PageSelector)
            {
                selector.SelectedButton(newTabName);
            }
        }
    }
}