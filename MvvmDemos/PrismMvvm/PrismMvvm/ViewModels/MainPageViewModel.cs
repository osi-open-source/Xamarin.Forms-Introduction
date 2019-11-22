using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PrismMvvm.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navService = navigationService;
        }

        public string PageText { get; set; } = "Welcome to Xamarin.Forms! This is text that is taken via Binding";

        public ICommand NavigateToNextPageCommand => new DelegateCommand(async () =>
        {
            var navParams = new NavigationParameters
            {
                { "PassedText", "This is text that is passed via NavigationParameters" }
            };
            await _navService.NavigateAsync("NextPage", navParams);
        });
    }
}
