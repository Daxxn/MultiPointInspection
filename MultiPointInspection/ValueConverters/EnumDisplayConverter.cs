using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MultiPointInspection.ValueConverters
{
    // Possibly dont need to use.
    // Also found on stack overflow, its probably utter shit.
    public class EnumDisplayConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {

            if (value == null)
                return DependencyProperty.UnsetValue;

            return GetDescription((Enum)value);
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }

        public static string GetDescription( Enum en )
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[ 0 ].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[ 0 ]).Description;
                }
            }
            return en.ToString();
        }
    }
}
