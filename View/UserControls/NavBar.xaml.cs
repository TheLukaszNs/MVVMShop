using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using MaterialDesignThemes.Wpf;
using MVVMShop.Model;
using MVVMShop.Services;
using MVVMShop.ViewModel;

namespace MVVMShop.View.UserControls
{
    public partial class NavBar : UserControl
    {
        public User User
        {
            get => (User)GetValue(UserNameProperty);
            set => SetValue(UserNameProperty, value);
        }

        public ICommand LogoutClickedCommand
        {
            get => (ICommand)GetValue(LogoutClickedCommandProperty);
            set => SetValue(LogoutClickedCommandProperty, value);
        }

        public PackIconKind ActionButtonKind
        {
            get => (PackIconKind)GetValue(ActionButtonKindProperty);
            set => SetValue(ActionButtonKindProperty, value);
        }

        public ICommand ActionButtonAction
        {
            get => (ICommand)GetValue(ActionButtonActionProperty);
            set => SetValue(ActionButtonActionProperty, value);
        }

        public ICommand HomeButtonAction
        {
            get => (ICommand)GetValue(HomeButtonActionProperty);
            set => SetValue(HomeButtonActionProperty, value);
        }

        public bool HasSecondaryAction
        {
            get => (bool)GetValue(HasSecondaryActionProperty);
            set => SetValue(HasSecondaryActionProperty, value);
        }

        public ICommand SecondaryAction
        {
            get => (ICommand)GetValue(SecondaryActionProperty);
            set => SetValue(SecondaryActionProperty, value);
        }

        public NavBar()
        {
            InitializeComponent();
        }

        private void ButtonLogout_OnClick(object sender, RoutedEventArgs e)
        {
            LogoutClickedCommand?.Execute(null);
        }

        private void ActionButton_OnClick(object sender, RoutedEventArgs e)
        {
            ActionButtonAction?.Execute(null);
        }

        private void HomeButton_OnClick(object sender, RoutedEventArgs e)
        {
            HomeButtonAction?.Execute(null);
        }

        private void SecondaryButton_OnClick(object sender, RoutedEventArgs e)
        {
            SecondaryAction?.Execute(null);
        }

        public void SetActionButtonIcon(PackIconKind kind)
        {
            ActionButton_Icon.Kind = kind;
        }

        public void SetSecondaryButtonVisible(bool visible)
        {
            SecondaryButton.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
            ;
        }

        public static readonly DependencyProperty SecondaryActionProperty = DependencyProperty.Register(
            nameof(SecondaryAction), typeof(ICommand), typeof(NavBar), new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty HasSecondaryActionProperty = DependencyProperty.Register(
            nameof(HasSecondaryAction), typeof(bool), typeof(NavBar),
            new PropertyMetadata(false, HasSecondaryPropertyChanged));

        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register(
            nameof(User), typeof(User), typeof(NavBar),
            new PropertyMetadata(null));

        public static readonly DependencyProperty LogoutClickedCommandProperty = DependencyProperty.Register(
            nameof(LogoutClickedCommand), typeof(ICommand), typeof(NavBar), new PropertyMetadata(null));

        public static readonly DependencyProperty ActionButtonActionProperty =
            DependencyProperty.Register(nameof(ActionButtonAction), typeof(ICommand), typeof(NavBar),
                new PropertyMetadata(null));

        public static readonly DependencyProperty ActionButtonKindProperty = DependencyProperty.Register(
            nameof(ActionButtonKind), typeof(PackIconKind), typeof(NavBar),
            new PropertyMetadata(PackIconKind.CartCheck, OnActionButtonChangedCallback));

        public static readonly DependencyProperty HomeButtonActionProperty = DependencyProperty.Register(
            nameof(HomeButtonAction), typeof(ICommand), typeof(NavBar), new PropertyMetadata(null));

        private static void HasSecondaryPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not NavBar navBar || e.NewValue is not bool shouldShow)
                return;

            navBar.SetSecondaryButtonVisible(shouldShow);
        }

        private static void OnActionButtonChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not NavBar navBar || e.NewValue is not PackIconKind kind)
                return;

            navBar.SetActionButtonIcon(kind);
        }
    }
}