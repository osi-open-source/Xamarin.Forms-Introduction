using Prism.DryIoc;
using Prism.Ioc;
using PrismMvvm.Services;
using PrismMvvm.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismMvvm
{
    public partial class App : PrismApplication
    {
        public App()
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<NextPage>();

            containerRegistry.Register<IItemsService, ItemsService>();
        }

        
    }
}
