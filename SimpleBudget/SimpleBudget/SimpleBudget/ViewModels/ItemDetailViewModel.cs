using System;

using SimpleBudget.Models;

namespace SimpleBudget.ViewModels
{
    public class ItemDetailViewModel : BasePageViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
