using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MultiPointInspection.ValueConverters
{
    public class BoolToVisibleConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            var boolVal = (bool)value;

            if (boolVal)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Hidden;
            }
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (value.GetType() == Visibility.Visible.GetType())
            {
                if ((Visibility)value == Visibility.Visible)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return null;
        }
    }
}
