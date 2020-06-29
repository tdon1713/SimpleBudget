using SimpleBudget.Models;
using SimpleBudget.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SimpleBudget.ViewModels
{
    public class MenuItemViewModel : BaseViewModel
    {
        private bool _isSelected;

        public MenuItemType Id { get; set; }

        public string Title { get; set; }

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
                    return Constants.Colors.Get(Constants.Colors.MenuSelectedBackgroundColor, Color.Teal);

                return Constants.Colors.Get(Constants.Colors.MenuBackgroundColor, Color.Black);
            }
        }
    }
}
