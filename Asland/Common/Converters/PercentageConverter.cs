namespace Asland.Common.Converters
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;

    /// <summary>
    /// Converter class which is used to create a width of a XAML object based on a percentage.
    /// It is a multi converter which takes two inputs, the first is a percentage and the second
    /// is the full width (i.e. the width of the XAML object for a 100% value). 
    /// In use, the second would use the actual width of a parent object.
    /// </summary>
    public class PercentageConverter : IMultiValueConverter
    {
        /// <summary>
        /// Convert a percentage and full width to a real width.
        /// </summary>
        /// <param name="values">
        /// Array of two values:
        /// 1 - A percentage of a full width.
        /// 2 - The fullest available width.
        /// </param>
        /// <param name="targetType">Not used</param>
        /// <param name="parameter">Not used</param>
        /// <param name="culture">Not used</param>
        /// <returns></returns>
        public object Convert(
            object[] values,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            if (values.Length != 2)
            {
                return (double)0;
            }

            if (values[0].GetType() != typeof(double) ||
                values[1].GetType() != typeof(double))
            {
                return (double)0;
            }

            if ((double)values[1] == 0)
            {
                return (double)0;
            }

            return System.Convert.ToDouble(values[0]) *
                   System.Convert.ToDouble(values[1])/100;
        }

        /// <summary>
        /// Convert back is not used.
        /// </summary>
        /// <param name="value">Not used</param>
        /// <param name="targetTypes">Not used</param>
        /// <param name="parameter">Not used</param>
        /// <param name="culture">Not used</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object[] ConvertBack(
            object value,
            Type[] targetTypes,
            object parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}