using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace BSWPFLib.Converter
{
  public class InvVisibilityConverter : IValueConverter
  {
    public virtual object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      if ((value is bool) && ((bool)value))
        return Visibility.Collapsed;

      return Visibility.Visible;
    }

    public virtual object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
