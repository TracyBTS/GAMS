using System;
using System.Windows;
using System.Globalization;
using System.Windows.Data;

namespace GAMS.SharedClasses.SharedConverters
{
    class Converter_VisibilityInverter : IValueConverter
    {
        /// <summary>
        /// Invert Visibility
        /// </summary>
        /// <param name="value">bool or Nullable bool</param>
        /// <param name="targetType">Visibility</param>
        /// <param name="parameter">null</param>
        /// <param name="culture">null</param>
        /// <returns>Visible or Collapsed</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility vValue = Visibility.Collapsed;
            if (value is Visibility)
            {
                vValue = (Visibility)value;
            }

            return vValue == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Invert Visibility
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility)
            {
                return (Visibility)value == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }
    }
}
