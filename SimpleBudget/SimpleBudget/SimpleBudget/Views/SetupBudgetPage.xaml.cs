
using SimpleBudget.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleBudget.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupBudgetPage : ContentPage
    {
        private SetupBudgetViewModel ViewModel => BindingContext as SetupBudgetViewModel;
        private string _id;

        public SetupBudgetPage(string id = "")
        {
            InitializeComponent();
            _id = id;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.Init(_id);
        }
    }
}