using SimpleBudget.Database;

namespace SimpleBudget.Utility
{
    public sealed class Globals
    {
        private static readonly object _lock = new object();
        private static Globals _inst;

        public static Globals Instance
        {
            get
            {
                lock(_lock)
                {
                    if (_inst == null)
                        _inst = new Globals();
                }

                return _inst;
            }
        }

        public static void Init()
        {
            var realm = RealmManager.Init();
            //Do any realm setup
        }
    }
}
