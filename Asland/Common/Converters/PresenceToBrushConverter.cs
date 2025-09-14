namespace Asland.Common.Converters
{
    using Asland.Common.Enums;
    using Asland.Common.Utils;
    using System;
    using System.Windows.Data;
    using System.Windows.Media;

    /// <summary>
    /// Used to convert a <see cref="ComponentState"/> value to a <see cref="Brush"/> to be used
    /// as the day icon background.
    /// </summary>
    [ValueConversion(typeof(Presence), typeof(Brush))]
    public class PresenceToBrushConverter : IValueConverter
    {
        /// <summary>
        /// Convert from a <see cref="Presence"/> to a <see cref="Brush"/>
        /// </summary>
        /// <param name="value">original value</param>
        /// <param name="targetType">target type is not used.</param>
        /// <param name="parameter">parameter is not used.</param>
        /// <param name="culture">culture is not used.</param>
        /// <returns>new brush</returns>
        public object Convert(
          object value,
          Type targetType,
          object parameter,
          System.Globalization.CultureInfo culture)
        {
            Color convertedColour;

            if (
              value == null ||
              value.GetType() != typeof(Presence))
            {
                convertedColour = ColourLibrary.UnknownColour;
            }
            else
            {
                convertedColour = 
                    PresenceUtility.Translate(
                        (Presence) value);
            }

            return new SolidColorBrush(convertedColour);
        }

        /// <summary>
        /// Not used.
        /// </summary>
        /// <param name="value">value is not used.</param>
        /// <param name="targetType">target type is not used.</param>
        /// <param name="parameter">parameter is not used.</param>
        /// <param name="culture">culture is not used.</param>
        /// <returns>no return</returns>
        public object ConvertBack(
          object value,
          Type targetType,
          object parameter,
          System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}