using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAMS.SharedClasses.SharedConverters
{
   
    public class DebugConverter : System.Windows.Data.IValueConverter
    {

        public Object Convert(Object value, Type targetType, Object parameter, System.Globalization.CultureInfo culture)
        {

            //set a breakpoint here
            return value;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, System.Globalization.CultureInfo culture)
        {

            //set a breakpoint here
            return value;
        }
    }

    public class RadComboBoxItemConverter : System.Windows.Data.IValueConverter
    {

        public Object Convert(Object value, Type targetType, Object parameter, System.Globalization.CultureInfo culture)
        {
            return 3;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, System.Globalization.CultureInfo culture)
        {

            //set a breakpoint here
            return value;
        }
    }

    public class RowDeatilsConverter : System.Windows.Data.IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, System.Globalization.CultureInfo culture)
        {

            //set a breakpoint here
            return value;
        }
    }


}
