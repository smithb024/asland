namespace Asland.ViewModels.Common
{
    using System;
    using System.Windows.Input;
    using Interfaces.ViewModels.Common;
    using NynaeveLib.Commands;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// A view model for a single selectable component with the enumeration selector 
    /// <see cref="IEnumSelectorViewModel{TEnum}"/>.
    /// The enumeration selector will present one of these for each enumerate in the 
    /// enumeration.
    /// When selected, the enumeration selector will return a value equal to the
    /// value represented by this component.
    /// </summary>
    /// <typeparam name="TEnum">Subject enumeration</typeparam>
    public class EnumComponentViewModel<TEnum> : ViewModelBase, IEnumComponentViewModel<TEnum> where TEnum : struct, IConvertible, IComparable, IFormattable
    {
        /// <summary>
        /// The value which is currently assigned to the enumeration selector.
        /// </summary>
        private TEnum currentValue;

        /// <summary>
        /// Initialises a new instance of the <see cref="EnumComponentViewModel{TEnum}"/> class.
        /// </summary>
        /// <param name="representative">
        /// The enumerate which this component represents.
        /// </param>
        /// <param name="current">
        /// The currently selected enumerate.
        /// </param>
        /// <param name="action">
        /// The action to run when this component is selected.
        /// </param>
        public EnumComponentViewModel(
            TEnum representative,
            TEnum current,
            Action<TEnum> action)
        {
            this.RepresentativeValue = representative;
            this.Name = representative.ToString();
            this.currentValue = current;
            this.Action = action;

            this.SelectStateCommand =
                new CommonCommand(
                    this.Select);
        }

        /// <summary>
        /// Gets the enumeration value within <see cref="TEnum"/> which is represented by this 
        /// interface.
        /// </summary>
        public TEnum RepresentativeValue { get; }

        /// <summary>
        /// Gets the name of this value which is displayed to the user.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the currently selected value within the selector component as a whole.
        /// </summary>
        public TEnum CurrentValue
        {
            get
            {
                return this.currentValue;
            }

            private set
            {
                this.currentValue = value;
            }
        }

        /// <summary>
        /// Gets a value which indicates whether this component is currently selected.
        /// </summary>
        public bool IsSelected => this.RepresentativeValue.CompareTo(this.CurrentValue) == 0;

        /// <summary>
        /// Gets the method to action when this component is selected by the user.
        /// </summary>
        public Action<TEnum> Action { get; }

        /// <summary>
        /// Gets the command presented to the user to allow them to select this component value.
        /// </summary>
        public ICommand SelectStateCommand { get; }

        /// <summary>
        /// Set the current value as defined within the enumeration selector component.
        /// </summary>
        /// <param name="newValue">new value</param>
        public void SetCurrent(TEnum newValue)
        {
            this.currentValue = newValue;
            this.OnPropertyChanged(nameof(this.IsSelected));
        }

        /// <summary>
        /// Select this <see cref="RepresentativeValue"/> as the current value within the 
        /// enumeration selector.
        /// </summary>
        private void Select()
        {
            this.Action.Invoke(this.RepresentativeValue);
        }
    }
}