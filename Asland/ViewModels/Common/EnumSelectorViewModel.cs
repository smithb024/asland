namespace Asland.ViewModels.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces.ViewModels.Common;
    using NynaeveLib.Commands;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// Interface which describes a component used by a user to select a enumerate value from all
    /// possible enumeration values.
    /// </summary>
    /// <typeparam name="TEnum">Subject enumeration</typeparam>
    public class EnumSelectorViewModel<TEnum> : ViewModelBase, IEnumSelectorViewModel<TEnum> where TEnum : struct, IConvertible, IComparable, IFormattable
    {
        /// <summary>
        /// The currently selected value.
        /// </summary>
        private TEnum current;

        /// <summary>
        /// Initialises a new instances of the <see cref="EnumSelectorViewModel{TEnum}"/> class
        /// </summary>
        /// <param name="name">The name of the component as presented to the user</param>
        /// <param name="initial">
        /// The initially selected value.
        /// </param>
        /// <param name="command">
        /// The method to invoke when a new value is selected.
        /// </param>
        public EnumSelectorViewModel(
            string name,
            TEnum initial,
            Action<TEnum> command)
        {
            this.Name = name;
            this.Action = command;
            this.current = initial;

            this.Controls = new List<IEnumComponentViewModel<TEnum>>();

            foreach (TEnum enumerate in Enum.GetValues(typeof(TEnum)))
            {
                EnumComponentViewModel<TEnum> newComponent =
                    new EnumComponentViewModel<TEnum>(
                        enumerate,
                        this.current,
                        this.Set);
                this.Controls.Add(newComponent);
            }
        }

        /// <summary>
        /// Gets the name of the comonent.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Collection of all the enumerate selector controls within the enumeration selector.
        /// </summary>
        public List<IEnumComponentViewModel<TEnum>> Controls { get; }

        /// <summary>
        /// Gets the action to invoke when a new enumerate is select.
        /// </summary>
        public Action<TEnum> Action { get; }

        /// <summary>
        /// Set a new current value.
        /// </summary>
        /// <param name="newValue">The new value</param>
        public void Set(TEnum newValue)
        {
            this.current = newValue;

            foreach(IEnumComponentViewModel<TEnum> control in this.Controls)
            {
                control.SetCurrent(this.current);
            }

            this.Action.Invoke(newValue);
        }
    }
}