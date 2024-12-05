using System.Globalization;
using System.Windows.Data;

namespace Weather_Api_With_MVVM.ViewModules.ValueConverters
{
    public class BoolToRainConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isRaining = (bool)value;
            if (isRaining)
            {
                return "Raining";
            }
            return "No Rain";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
