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

namespace MVVMShop.View.UserControls
{
    public partial class NavBar : UserControl
    {
        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register(
            nameof(UserName), typeof(string), typeof(NavBar),
            new PropertyMetadata(string.Empty));

        public string UserName
        {
            get => (string)GetValue(UserNameProperty);
            set => SetValue(UserNameProperty, value);
        }

        public static readonly DependencyProperty LogoutClickedCommandProperty = DependencyProperty.Register(
            nameof(LogoutClickedCommand), typeof(ICommand), typeof(NavBar), new PropertyMetadata(null));

        public ICommand LogoutClickedCommand
        {
            get => (ICommand)GetValue(LogoutClickedCommandProperty);
            set => SetValue(LogoutClickedCommandProperty, value);
        }

        public NavBar()
        {
            InitializeComponent();
        }

        private void ButtonLogout_OnClick(object sender, RoutedEventArgs e)
        {
            LogoutClickedCommand?.Execute(null);
        }
    }
}