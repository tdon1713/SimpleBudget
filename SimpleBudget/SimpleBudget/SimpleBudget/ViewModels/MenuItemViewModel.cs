using SimpleBudget.Utility;
using Xamarin.Forms;

namespace SimpleBudget.ViewModels
{
    public class MenuItemViewModel : BaseViewModel
    {
        private bool _isSelected;

        public MenuItems Id { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
                OnPropertyChanged(nameof(BackgroundColor));
            }
        }

        public Color BackgroundColor
        {
            get
            {
                if (_isSelected)
                    return Constants.Colors.Get(Constants.Colors.MediumColor, Color.Teal);

                return Constants.Colors.Get(Constants.Colors.DarkColor, Color.Black);
            }
        }
    }
}
