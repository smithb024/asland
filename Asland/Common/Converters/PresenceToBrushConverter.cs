﻿namespace Asland.Common.Converters
{
    using System;
    using System.Windows.Data;
    using System.Windows.Media;

    using Asland.Common.Enums;

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
                convertedColour = Colors.HotPink;
            }
            else
            {
                Presence convertedState = (Presence)value;

                switch (convertedState)
                {
                    case Presence.Breeding:
                        convertedColour = Colors.Tomato;
                        break;

                    case Presence.Hibernates:
                        convertedColour = Colors.PowderBlue;
                        break;

                    case Presence.NonBreeding:
                        convertedColour = Colors.DodgerBlue;
                        break;

                    case Presence.Passing:
                        convertedColour = Colors.DarkGoldenrod;
                        break;

                    case Presence.Resident:
                        convertedColour = Colors.ForestGreen;
                        break;

                    case Presence.Vagrant:
                        convertedColour = Colors.LightSteelBlue;
                        break;

                    default:
                        convertedColour = Colors.HotPink;
                        break;
                }
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