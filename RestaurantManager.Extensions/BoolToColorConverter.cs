using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace RestaurantManager.Extensions
{
    public class BoolToColorConverter : IValueConverter
    {
        public Color TrueColor { get; set; }

        public Color FalseColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Color returnValue = Colors.Transparent;
            if (value is bool)
            {
                returnValue = (bool)value ? TrueColor : FalseColor;
            }
            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool returnValue = default(bool);
            if (value is Color)
            {
                if ((Color)value == TrueColor) { returnValue = true; }
                else if ((Color)value == FalseColor) { returnValue = false; }
            }
            return returnValue;
        }
    }
}
