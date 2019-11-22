using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Styles.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstInheritedPage : BasePage
    {
        public FirstInheritedPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public ICommand GoToImagePageCommand => new Command(async () =>
        {
            await Shell.Current.GoToAsync("//images");
        });
    }
}