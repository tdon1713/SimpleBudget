using SimpleBudget.Models;
using System.Drawing;

namespace SimpleBudget.ViewModels
{
    public class BudgetListItemViewModel
    {
        public BudgetListItemViewModel(Budget budget)
        {
            ID = budget.Id;
            Name = budget.Name;
            Description = budget.Description;
            Progress = budget.Balance / budget.Goal;
            ProgressString = $"{string.Format("{0:C}", budget.Balance)} / {string.Format("{0:C}", budget.Goal)}";
        }

        public string ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Progress { get; set; }

        public string ProgressString { get; set; }

        public Color ProgressColor
        {
            get
            {
                if (IsCompleted)
                    return Color.FromArgb(60, 158, 128);

                return Color.FromArgb(137, 208, 208);
            }
        }

        public bool IsCompleted => Progress >= 1;
    }
}
