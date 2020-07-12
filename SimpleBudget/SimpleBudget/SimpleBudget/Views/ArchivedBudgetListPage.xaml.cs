using SimpleBudget.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleBudget.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArchivedBudgetListPage : ContentPage
    {
        private ArchivedBudgetListViewModel ViewModel => BindingContext as ArchivedBudgetListViewModel;

        public ArchivedBudgetListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Init();
        }
    }
}