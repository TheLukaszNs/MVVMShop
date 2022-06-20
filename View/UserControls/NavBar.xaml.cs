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

        public static readonly DependencyProperty UserManagementCommandProperty = DependencyProperty.Register(
            nameof(UserManagementCommand), typeof(ICommand), typeof(NavBar), new PropertyMetadata(null));

        public static readonly DependencyProperty CartCommandProperty = DependencyProperty.Register(
            nameof(CartCommand), typeof(ICommand), typeof(NavBar), new PropertyMetadata(null));

        public static readonly DependencyProperty LogoutClickedCommandProperty = DependencyProperty.Register(
            nameof(LogoutClickedCommand), typeof(ICommand), typeof(NavBar), new PropertyMetadata(null));

        public ICommand UserManagementCommand
        {
            get => (ICommand)GetValue(UserManagementCommandProperty);
            set => SetValue(UserManagementCommandProperty, value);
        }

        public ICommand CartCommand
        {
            get => (ICommand)GetValue(CartCommandProperty);
            set => SetValue(CartCommandProperty, value);
        }
        public ICommand LogoutClickedCommand
        {
            get => (ICommand)GetValue(LogoutClickedCommandProperty);
            set => SetValue(LogoutClickedCommandProperty, value);
        }

        public NavBar()
        {
            InitializeComponent();
        }

        private void ButtonUserManagement_OnClick(object sender, RoutedEventArgs e)
        {
            UserManagementCommand?.Execute(null);
        }

        private void ButtonCart_OnClick(object sender, RoutedEventArgs e)
        {
            CartCommand?.Execute(null);
        }

        private void ButtonLogout_OnClick(object sender, RoutedEventArgs e)
        {
            LogoutClickedCommand?.Execute(null);
        }
    }
}