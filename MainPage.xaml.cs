using System.Windows;
using System.Windows.Data;
using MenuItemMvvm.Infrastructure;
using MenuItemMvvm.ViewModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MenuItemMvvm
{
    public partial class MainPage : PhoneApplicationPage
    {
        MainViewModel vm = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            DataContext = vm;
            ApplicationBarMenuItem menuItem = ApplicationBar.MenuItems[0] as ApplicationBarMenuItem;

            MenuStateControl menuStateControl = new MenuStateControl(menuItem);
            Binding binding = new Binding
                {
                    Path = new PropertyPath("IsMenuEnabled"), 
                    Source = DataContext
                };

            menuStateControl.SetBinding(MenuStateControl.StateProperty, binding);
        }
    }
}