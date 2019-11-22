using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Navigation;
using PrismMvvm.Services;

namespace PrismMvvm.ViewModels
{
    public class NextPageViewModel : ViewModelBase
    {
        private readonly IItemsService _itemsService;
        private string _passedText;
        private ObservableCollection<string> _items;

        public NextPageViewModel(IItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        public string PassedText 
        { 
            get => _passedText; 
            private set
            {
                _passedText = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<string> Items
        {
            get => _items;
            set
            {
                _items = value;
                RaisePropertyChanged();
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            PassedText = parameters.GetValue<string>("PassedText");
            Items = new ObservableCollection<string>(_itemsService.GetItems());
        }
    }
}
