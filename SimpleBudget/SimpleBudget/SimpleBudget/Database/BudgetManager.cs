using SimpleBudget.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBudget.Database
{
    public class BudgetManager : RealmManager
    {
        public static SBResult Archive(string id)
        {
            var realm = GetDatabase();
            var budget = realm.Find<Budget>(id);
            if (budget == null)
                return SBResult.Error("Budget cannot be found");

            realm.Write(() =>
            {
                budget.Archived = true;
            });

            return SBResult.Success();
        }

        public static SBResult Delete(string id)
        {
            var realm = GetDatabase();
            var budget = realm.Find<Budget>(id);
            if (budget == null)
                return SBResult.Error("Budget cannot be found");

            realm.Write(() =>
            {
                realm.Remove(budget);
            });

            return SBResult.Success();
        }

        public static Budget Get(string id)
        {
            var realm = GetDatabase();
            return realm.Find<Budget>(id);
        }

        public static List<Budget> Get(bool archived = false)
        {
            var realm = GetDatabase();
            return realm.All<Budget>().Where(t => t.Archived == archived).ToList();
        }

        public static SBResult Add(string name, string description, double? balance = 0, double? goal = 0)
        {
            SBResult result = Validate(name, goal);
            if (!result.Result)
                return result;

            var realm = GetDatabase();
            realm.Write(() =>
            {
                Budget local = new Budget();
                local.Name = name.Trim();
                local.Description = description?.Trim() ?? string.Empty;
                local.Balance = balance.HasValue ? balance.Value : 0;
                local.Goal = goal.Value;

                realm.Add(local, update: false);
            });

            return SBResult.Success();
        }

        public static SBResult Unarchive(string id)
        {
            var realm = GetDatabase();
            var budget = realm.Find<Budget>(id);
            if (budget == null)
                return SBResult.Error("Budget cannot be found");

            realm.Write(() =>
            {
                budget.Archived = false;
            });

            return SBResult.Success();
        }

        public static SBResult Update(string id, string name, string description, double? balance = 0, double? goal = 0)
        {
            SBResult result = Validate(name, goal);
            if (!result.Result)
                return result;

            if (string.IsNullOrEmpty(id))
                return SBResult.Error("Cannot update requested budget");

            var realm = GetDatabase();
            var budget = realm.Find<Budget>(id);
            if (budget == null)
                return SBResult.Error("Requested budget cannot be found");

            realm.Write(() =>
            {
                budget.Name = name.Trim();
                budget.Description = description?.Trim() ?? string.Empty;
                budget.Balance = balance.HasValue ? balance.Value : 0;
                budget.Goal = goal.Value;

                realm.Add(budget, update: true);
            });

            return SBResult.Success();
        }

        private static SBResult Validate(string name, double? goal = 0)
        {
            if (string.IsNullOrEmpty(name?.Trim()))
                return SBResult.Error("Name cannot be empty");

            if (!goal.HasValue || goal.Value <= 0)
                return SBResult.Error("Goal cannot be 0");

            return SBResult.Success();
        }
    }
}
