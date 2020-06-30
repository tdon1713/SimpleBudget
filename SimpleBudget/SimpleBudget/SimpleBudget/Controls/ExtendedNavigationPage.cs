using SimpleBudget.Utility;
using Xamarin.Forms;

namespace SimpleBudget.Controls
{
    public class ExtendedNavigationPage : NavigationPage
    {
        public ExtendedNavigationPage(Page root) : base(root)
        {
            BarBackgroundColor = Constants.Colors.Get(Constants.Colors.NavigationBarColor, Color.Teal);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CurrentPage.BackgroundColor = Constants.Colors.Get(Constants.Colors.PageBackgroundColor, Color.DarkGray);
        }
    }
}
