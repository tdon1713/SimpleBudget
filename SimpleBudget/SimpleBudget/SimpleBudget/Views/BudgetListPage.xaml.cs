using SimpleBudget.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleBudget.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BudgetListPage : ContentPage
    {
        private BudgetListViewModel ViewModel => BindingContext as BudgetListViewModel;

        public BudgetListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Init();
        }

        private void DeleteItem_Invoked(object sender, System.EventArgs e)
        {
            var item = ((SwipeItem)sender).BindingContext as BudgetListItemViewModel;
            ViewModel.DeleteItemCommand.Execute(item);
        }

        private void ArchiveItem_Invoked(object sender, System.EventArgs e)
        {
            var item = ((SwipeItem)sender).BindingContext as BudgetListItemViewModel;
            ViewModel.ArchiveItemCommand.Execute(item);
        }
    }
}