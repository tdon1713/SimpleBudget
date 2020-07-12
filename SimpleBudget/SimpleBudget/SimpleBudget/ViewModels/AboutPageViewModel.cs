namespace SimpleBudget.ViewModels
{
    public class AboutPageViewModel : BasePageViewModel
    {
        public string Version
        {
            get => Xamarin.Essentials.AppInfo.VersionString;
        }

        public AboutPageViewModel()
        {
            Title = "About";
        }
    }
}
