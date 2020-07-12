using Xamarin.Forms;

namespace SimpleBudget.Controls
{
    public class ExtendedButton : Button
    {
        public static readonly BindableProperty TintColorProperty = BindableProperty.Create(
            nameof(TintColorProperty),
            typeof(Color),
            typeof(ExtendedButton),
            Color.Default);

        public Color TintColor
        {
            get => (Color)GetValue(TintColorProperty);
            set => SetValue(TintColorProperty, value);
        }
    }
}
