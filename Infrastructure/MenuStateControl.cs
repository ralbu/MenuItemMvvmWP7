using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Shell;

namespace MenuItemMvvm.Infrastructure
{
    public class MenuStateControl : UserControl
    {
        private static ApplicationBarMenuItem _menuItem;
        public MenuStateControl(ApplicationBarMenuItem menuItem)
        {
            _menuItem = menuItem;
        }

        public bool State
        {
            get { return (bool)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
       "State", typeof(string), typeof(MenuStateControl), new PropertyMetadata(String.Empty, OnCallBack));


        private static void OnCallBack(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null) return;
            bool isEnabled;
            if (Boolean.TryParse(e.NewValue.ToString(), out isEnabled))
            {
                _menuItem.IsEnabled = isEnabled;
            }

        }

    }

}
