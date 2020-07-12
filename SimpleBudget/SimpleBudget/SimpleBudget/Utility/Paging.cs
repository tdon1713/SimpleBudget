using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleBudget.Utility
{
    public static class Paging
    {
        public static async Task PushAsync(Page page)
        {
            await ((Application.Current.MainPage as MasterDetailPage).Detail as NavigationPage).PushAsync(page);
        }

        public static async Task PopAsync()
        {
            await ((Application.Current.MainPage as MasterDetailPage).Detail as NavigationPage).PopAsync();
        }
    }
}
