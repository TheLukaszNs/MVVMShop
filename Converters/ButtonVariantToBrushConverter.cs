using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using MVVMShop.View;
using System.Windows.Media;

namespace MVVMShop.Converters
{
    internal class ButtonVariantToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var brushConverter = new BrushConverter();
            
            if (!(value is ButtonVariant))
                return (SolidColorBrush)brushConverter.ConvertFrom("#00B894");

            switch (value)
            {
                case ButtonVariant.Default:
                    return (SolidColorBrush)brushConverter.ConvertFrom("#00B894");
                case ButtonVariant.Accent:
                    return (SolidColorBrush)brushConverter.ConvertFrom("#FDCB6E");
                case ButtonVariant.Danger:
                    return (SolidColorBrush)brushConverter.ConvertFrom("#D63031");
                default:
                    return (SolidColorBrush)brushConverter.ConvertFrom("#00B894");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
