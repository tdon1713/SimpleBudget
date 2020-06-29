using SimpleBudget.Models;
using SimpleBudget.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleBudget.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<MenuItemViewModel> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<MenuItemViewModel>
            {
                new MenuItemViewModel {Id = MenuItemType.Browse, Title="Browse", IsSelected = true },
                new MenuItemViewModel {Id = MenuItemType.About, Title="About" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var selectedItem = (MenuItemViewModel)e.SelectedItem;
                foreach (var item in menuItems)
                {
                    if (item.IsSelected)
                    {
                        item.IsSelected = false;
                        break;
                    }
                }

                selectedItem.IsSelected = true;
                var id = (int)selectedItem.Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}