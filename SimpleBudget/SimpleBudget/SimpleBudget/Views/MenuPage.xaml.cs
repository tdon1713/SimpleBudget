﻿using SimpleBudget.Utility;
using SimpleBudget.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace SimpleBudget.Views
{
    //TODO: Add Settings Option
    //TODO: Add ads
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        private MainPage RootPage => Application.Current.MainPage as MainPage; 
        private List<MenuItemViewModel> menuItems;

        public MenuPage()
        {
            InitializeComponent();
            

            menuItems = new List<MenuItemViewModel>
            {
                new MenuItemViewModel {Id = MenuItems.Budgets, Title="Budgets", IsSelected = true, Icon = "\uf555" },
                new MenuItemViewModel {Id = MenuItems.Archive, Title="Archive", Icon = "\uf187" },
                new MenuItemViewModel {Id = MenuItems.About, Title="About", Icon = "\uf05a" }
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
                await RootPage.NavigateFromMenu(selectedItem.Id);
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    imgHeader.Source = ImageSource.FromFile("Header_Landscape.png");
                    break;
                case Device.UWP:
                    imgHeader.Source = ImageSource.FromFile("Header_Landscape.png");
                    break;
            }
        }
    }
}