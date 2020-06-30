using SimpleBudget.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBudget.Database
{
    public class BudgetManager : RealmManager
    {
        public List<Budget> Get()
        {
            var realm = GetDatabase();
            return realm.All<Budget>().ToList();
        }
    }
}
