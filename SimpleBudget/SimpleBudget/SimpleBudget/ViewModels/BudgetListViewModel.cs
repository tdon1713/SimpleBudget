using SimpleBudget.Database;
using SimpleBudget.Models;
using SimpleBudget.Utility;
using SimpleBudget.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleBudget.ViewModels
{
    public class BudgetListViewModel : BasePageViewModel
    {
        private ObservableCollection<BudgetListItemViewModel> _budgets;
        private BudgetListItemViewModel _selectedBudget;
        private ICommand _addBudgetCommand;
        private ICommand _refreshCommand;
        private ICommand _budgetSelectedCommand;
        private ICommand _archiveItemCommand;
        private ICommand _deleteItemCommand;

        public ICommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new Command(() => LoadBudgets()));

        public ICommand AddBudgetCommand => _addBudgetCommand ?? (_addBudgetCommand = new Command(() => AddBudget()));

        public ICommand BudgetSelectedCommand => _budgetSelectedCommand ?? (_budgetSelectedCommand = new Command<BudgetListItemViewModel>(async (item) => await BudgetSelected(item)));

        public ICommand ArchiveItemCommand => _archiveItemCommand ?? (_archiveItemCommand = new Command<BudgetListItemViewModel>(async (item) => await ArchiveItem(item)));

        public ICommand DeleteItemCommand => _deleteItemCommand ?? (_deleteItemCommand = new Command<BudgetListItemViewModel>(async (item) => await DeleteItem(item)));

        public BudgetListItemViewModel SelectedBudget
        {
            get => _selectedBudget;
            set => SetProperty(ref _selectedBudget, value);
        }

        public ObservableCollection<BudgetListItemViewModel> Budgets
        {
            get => _budgets ?? (_budgets = new ObservableCollection<BudgetListItemViewModel>());
            set
            {
                SetProperty(ref _budgets, value);
                OnPropertyChanged(nameof(HasBudgets));
            }
        }

        public bool HasBudgets
        {
            get => _budgets?.Count > 0;
        }

        public BudgetListViewModel()
        {
            Title = "Budgets";
        }

        public override void Init()
        {
            LoadBudgets();
        }

        private async void AddBudget()
        {
            await Paging.PushAsync(new SetupBudgetPage());
        }

        private void LoadBudgets()
        {
            IsBusy = true;

            var budgets = BudgetManager.Get();
            var vmList = budgets.Select(t => new BudgetListItemViewModel(t)).ToList();

#if DEBUG
            //if (budgets.Count == 0)
            //{
            //    Random random = new Random();

            //    for (int a = 0; a < 15; a++)
            //    {
            //        vmList.Add(new BudgetListItemViewModel(new Budget
            //        {
            //            Id = Guid.Empty.ToString(),
            //            Name = "Debug Item #" + a,
            //            Description = "Hi",
            //            Balance = random.NextDouble() * (2000 - 1) + 1,
            //            Goal = random.NextDouble() * (3000 - 1) + 1
            //        }));
            //    }
            //}
#endif

            Budgets = new ObservableCollection<BudgetListItemViewModel>(vmList);
            IsBusy = false;
        }

        private async Task BudgetSelected(BudgetListItemViewModel item)
        {
            SelectedBudget = null;

            if (item == null)
                return;

            await Paging.PushAsync(new SetupBudgetPage(item.ID));
        }

        private async Task ArchiveItem(BudgetListItemViewModel item)
        {
            if (item == null)
                return;

            bool success = await Budget.Archive(item.ID, fromSetup: false);
            if (success)
                LoadBudgets();
        }

        private async Task DeleteItem(BudgetListItemViewModel item)
        {
            if (item == null)
                return;

            bool success = await Budget.Delete(item.ID, fromSetup: false);
            if (success)
                LoadBudgets();
        }
    }
}
