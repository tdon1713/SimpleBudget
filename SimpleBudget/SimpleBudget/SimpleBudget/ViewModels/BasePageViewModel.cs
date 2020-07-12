using Acr.UserDialogs;
using System.Threading.Tasks;

namespace SimpleBudget.ViewModels
{
    public class BasePageViewModel : BaseViewModel
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public virtual void Init() { }

        public virtual Task Init(string id = "") => Task.CompletedTask;

        protected void ShowLoading()
        {
            UserDialogs.Instance.ShowLoading();
        }

        protected void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }

        protected async Task AlertAsync(string message, string title = "", string okText = "OK")
        {
            await UserDialogs.Instance.AlertAsync(message, title, okText);
        }

        protected async Task<bool> ConfirmAsync(string message, string title = "", string okText = "Yes", string cancelText = "No")
        {
            return await UserDialogs.Instance.ConfirmAsync(message, title, okText, cancelText);
        }
    }
}
