using Xamarin.Forms;

namespace SimpleBudget.Utility
{
    public static class Constants
    {
        public static class Colors
        {
            public const string MediumDarkColor = nameof(MediumDarkColor);
            public const string DarkColor = nameof(DarkColor);
            public const string MediumColor = nameof(MediumColor);
            public const string NavigationBarColor = nameof(NavigationBarColor);

            public static Color Get(string resourceName, Color defaultColor)
            {
                if (Application.Current.Resources.ContainsKey(resourceName))
                    return (Color)Application.Current.Resources[resourceName];

                return defaultColor;
            }
        }
    }
}
