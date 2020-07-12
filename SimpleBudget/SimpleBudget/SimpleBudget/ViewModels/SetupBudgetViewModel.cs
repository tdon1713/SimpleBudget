using SimpleBudget.Database;
using SimpleBudget.Models;
using SimpleBudget.Utility;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleBudget.ViewModels
{
    public class SetupBudgetViewModel : BasePageViewModel
    {
        private bool _newBudget = true;
        private ICommand _saveCommand;
        private ICommand _deleteCommand;
        private ICommand _archiveCommand;

        private string _id;
        private string _name;
        private string _description;
        private double? _current;
        private double? _goal;

        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new Command(async () => await Save()));

        public ICommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new Command(async () => await Delete()));

        public ICommand ArchiveCommand => _archiveCommand ?? (_archiveCommand = new Command(async () => await Archive()));

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public double? Balance
        {
            get => _current;
            set => SetProperty(ref _current, value);
        }

        public double? Goal
        {
            get => _goal;
            set => SetProperty(ref _goal, value);
        }

        public bool NewBudget
        {
            get => _newBudget;
            set => SetProperty(ref _newBudget, value);
        }

        public override async Task Init(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                Title = "Add Budget";
                return;
            }

            _id = id;
            Title = "Update Budget";
            ShowLoading();

            try
            {
                var budget = BudgetManager.Get(_id);
                if (budget == null)
                    throw new Exception("Request budget cannot be found");

                Name = budget.Name;
                Description = budget.Description;
                Balance = budget.Balance;
                Goal = budget.Goal;
                NewBudget = false;
            }
            catch (Exception ex)
            {
                await AlertAsync(ex.Message, "Save Error");
                await Paging.PopAsync();
            }
            finally
            {
                HideLoading();
            }
        }

        private async Task Save()
        {
            try
            {
                ShowLoading();
                SBResult result = null;
                if (_newBudget)
                    result = BudgetManager.Add(Name, Description, Balance, Goal);
                else
                    result = BudgetManager.Update(_id, Name, Description, Balance, Goal);

                if (!result.Result)
                    await AlertAsync(result.Message, "Save Error");
                else
                    await Paging.PopAsync();
            }
            catch (Exception ex)
            {
                await AlertAsync(ex.Message, "Save Error");
            }
            finally
            {
                HideLoading();
            }
        }

        private async Task Delete()
        {
            if (NewBudget)
                return;

            await Budget.Delete(_id);
        }

        private async Task Archive()
        {
            if (NewBudget)
                return;

            await Budget.Archive(_id);
        }
    }
}
