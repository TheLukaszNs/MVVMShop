using MVVMShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMShop.View
{
    public class ConstrainedTextField : TextBox
    {
        public ButtonVariant Variant
        {
            get { return (ButtonVariant)GetValue(VariantProperty); }
            set { SetValue(VariantProperty, value); }
        }

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        static ConstrainedTextField()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ConstrainedTextField), new FrameworkPropertyMetadata(typeof(ConstrainedTextField)));
        }

        public static readonly DependencyProperty VariantProperty =
            DependencyProperty.Register(nameof(Variant), typeof(ButtonVariant), typeof(ConstrainedTextField), new PropertyMetadata(ButtonVariant.Default));

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(ConstrainedTextField), new PropertyMetadata(string.Empty));
    }
}
