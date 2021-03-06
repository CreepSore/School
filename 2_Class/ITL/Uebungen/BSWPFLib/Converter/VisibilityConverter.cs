﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace BSWPFLib.Converter
{
  public class VisibilityConverter : IValueConverter
  {
    public virtual object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      if ((value is bool) && ((bool)value))
        return Visibility.Visible;

      return Visibility.Collapsed;
    }

    public virtual object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
