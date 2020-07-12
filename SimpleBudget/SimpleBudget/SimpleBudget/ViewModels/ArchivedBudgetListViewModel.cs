using SimpleBudget.Database;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleBudget.ViewModels
{
    public class ArchivedBudgetListViewModel : BasePageViewModel
    {
        private ObservableCollection<BudgetListItemViewModel> _budgets;
        private BudgetListItemViewModel _selectedBudget;
        private ICommand _budgetSelectedCommand;

        public ICommand BudgetSelectedCommand => _budgetSelectedCommand ?? (_budgetSelectedCommand = new Command<BudgetListItemViewModel>(async (item) => await BudgetSelected(item)));


        public BudgetListItemViewModel SelectedBudget
        {
            get => _selectedBudget;
            set => SetProperty(ref _selectedBudget, value);
        }

        public ObservableCollection<BudgetListItemViewModel> Budgets
        {
            get => _budgets ?? (_budgets = new ObservableCollection<BudgetListItemViewModel>());
            set => SetProperty(ref _budgets, value);
        }

        public ArchivedBudgetListViewModel()
        {
            Title = "Archived Budgets";
        }

        public override void Init()
        {
            LoadBudgets();
        }

        private void LoadBudgets()
        {
            IsBusy = true;

            var budgets = BudgetManager.Get(archived: true);
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

            var confirm = await ConfirmAsync("Would you like to remove this budget from the archive?", "Unarchive");
            if (!confirm)
                return;

            ShowLoading();

            try
            {
                var result = BudgetManager.Unarchive(item.ID);
                if (!result.Result)
                    await AlertAsync(result.Message, "Unarchive Error");
                else
                    Budgets.Remove(item);
            }
            catch (Exception ex)
            {
                await AlertAsync(ex.Message, "Unarchive Error");
            }
            finally
            {
                HideLoading();
            }
        }
    }
}
