using Xamarin.Forms;

namespace SimpleBudget.Utility
{
    public static class Constants
    {
        public static class Colors
        {
            public const string PageBackgroundColor = nameof(PageBackgroundColor);
            public const string MenuBackgroundColor = nameof(MenuBackgroundColor);
            public const string MenuSelectedBackgroundColor = nameof(MenuSelectedBackgroundColor);

            public static Color Get(string resourceName, Color defaultColor)
            {
                if (Application.Current.Resources.ContainsKey(resourceName))
                    return (Color)Application.Current.Resources[resourceName];

                return defaultColor;
            }
        }
    }
}
