using Realms;
using System.IO;

namespace SimpleBudget.Database
{
    public class RealmManager
    {
        private static RealmConfiguration _config = new RealmConfiguration(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "simplebudget.realm"))
        {
            SchemaVersion = 1,
            ShouldDeleteIfMigrationNeeded = true
        };

        protected static Realm GetDatabase()
        {
            return Realm.GetInstance(_config);
        }

        public static Realm Init()
        {
            return Realm.GetInstance(_config);
        }
    }
}
