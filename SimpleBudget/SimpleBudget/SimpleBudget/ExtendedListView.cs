using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleBudget
{
    public class ExtendedListView : ListView
    {
        public static BindableProperty ItemSelectedCommandProperty = BindableProperty.Create(
            propertyName: nameof(ItemSelectedCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(ListView),
            defaultValue: null);

        public ICommand ItemSelectedCommand
        {
            get { return (ICommand)GetValue(ItemSelectedCommandProperty); }
            set { SetValue(ItemSelectedCommandProperty, value); }
        }

        public static readonly BindableProperty NestedScrollingEnabledProperty = BindableProperty.Create(
            nameof(IsNestedScrollingEnabled),
            typeof(bool),
            typeof(ExtendedListView),
            false);

        public bool IsNestedScrollingEnabled
        {
            get => (bool)GetValue(NestedScrollingEnabledProperty);
            set => SetValue(NestedScrollingEnabledProperty, value);
        }

        public ExtendedListView() : base(ListViewCachingStrategy.RecycleElement)
        {
            ItemTapped += Handle_ItemTapped;
        }

        public ExtendedListView(ListViewCachingStrategy cachingStrategy) : base(cachingStrategy)
        {
            ItemTapped += Handle_ItemTapped;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext == null)
            {
                ItemTapped -= Handle_ItemTapped;
            }
        }

        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && ItemSelectedCommand != null && ItemSelectedCommand.CanExecute(e.Item))
            {
                ItemSelectedCommand.Execute(e.Item);
                SelectedItem = null;
            }
        }
    }
}