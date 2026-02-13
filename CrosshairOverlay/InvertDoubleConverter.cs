using System;
using System.Globalization;
using System.Windows.Data;

namespace CrosshairOverlay
{
    // ValueConverters allow us to change data before it hits the UI.
    // This one simply multiplies by -1.
    public class InvertDoubleConverter : IValueConverter
    {
        // One-Way: From ViewModel (Slider) -> View (UI)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double d)
            {
                return d * -1;
            }
            return 0;
        }

        // Two-Way: From View (UI) -> ViewModel (Slider) - Not really needed here, but good practice
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double d)
            {
                return d * -1;
            }
            return 0;
        }
    }
}