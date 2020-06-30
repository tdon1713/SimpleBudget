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
    public partial class BudgetListPage : ContentPage
    {
        public BudgetListPage()
        {
            InitializeComponent();
        }
    }
}