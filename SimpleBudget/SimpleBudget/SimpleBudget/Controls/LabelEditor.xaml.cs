using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleBudget.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelEditor : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(LabelEditor),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            validateValue: null);

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(LabelEditor),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            validateValue: null);

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            nameof(Placeholder),
            typeof(string),
            typeof(LabelEditor),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            validateValue: null);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public LabelEditor()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            EditorField.Focus();
        }

        public new void Focus()
        {
            EditorField.Focus();
        }
    }
}