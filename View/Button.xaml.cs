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
    public partial class Button : UserControl
    {
        public ButtonVariant Variant
        {
            get { return (ButtonVariant)GetValue(VariantProperty); }
            set { SetValue(VariantProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public Button()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        public static readonly DependencyProperty VariantProperty =
            DependencyProperty.Register(nameof(Variant), typeof(ButtonVariant), typeof(Button), new PropertyMetadata(ButtonVariant.Default));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(Button), new PropertyMetadata(string.Empty));


    }
}
