using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using SimpleBudget.Utility;
using SimpleBudget.Controls;

namespace SimpleBudget.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<MenuItems, NavigationPage> MenuPages = new Dictionary<MenuItems, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.UWP)
                MasterBehavior = MasterBehavior.Split;
            else
                MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add(MenuItems.Budgets, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(MenuItems id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case MenuItems.Budgets:
                        MenuPages.Add(id, new ExtendedNavigationPage(new BudgetListPage()));
                        break;
                    case MenuItems.Archive:
                        MenuPages.Add(id, new ExtendedNavigationPage(new ArchivedBudgetListPage()));
                        break;
                    case MenuItems.About:
                        MenuPages.Add(id, new ExtendedNavigationPage(new AboutPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];
            if (newPage != null && Detail != newPage)
            {
                await newPage.PopToRootAsync();
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                if (MasterBehavior != MasterBehavior.Split)
                    IsPresented = false;
            }
        }
    }
}