using Acr.UserDialogs;
using Realms;
using SimpleBudget.Database;
using SimpleBudget.Utility;
using System;
using System.Threading.Tasks;

namespace SimpleBudget.Models
{
    public class Budget : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Indexed]
        public string Name { get; set; }

        public string Description { get; set; }

        public double Balance { get; set; }

        public double Goal { get; set; }

        public bool Archived { get; set; } = false;

        public static async Task<bool> Archive(string id, bool fromSetup = true)
        {
            var confirm = await UserDialogs.Instance.ConfirmAsync("Archive the current budget?", "Archive?", "Yes", "No");
            if (!confirm)
                return false;

            UserDialogs.Instance.ShowLoading();

            try
            {
                var result = BudgetManager.Archive(id);
                if (!result.Result)
                    await UserDialogs.Instance.AlertAsync(result.Message, "Archive Error");
                else if (fromSetup)
                    await Paging.PopAsync();
                else
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(ex.Message, "Archive Error");
                return false;
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        public static async Task<bool> Delete(string id, bool fromSetup = true)
        {
            try
            {
                var confirm = await UserDialogs.Instance.ConfirmAsync("Delete the current budget?", "Delete?", "Yes", "No");
                if (!confirm)
                    return false;

                UserDialogs.Instance.ShowLoading();
                var result = BudgetManager.Delete(id);
                if (!result.Result)
                    await UserDialogs.Instance.AlertAsync(result.Message, "Delete Error");
                else if (fromSetup)
                    await Paging.PopAsync();
                else
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(ex.Message, "Delete Error");
                return false;
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }
    }
}