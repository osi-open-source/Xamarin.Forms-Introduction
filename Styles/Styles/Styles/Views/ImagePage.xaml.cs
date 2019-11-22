
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Styles.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        public ImagePage()
        {
            InitializeComponent();
            EmbeddedImage.Source = ImageSource.FromResource("Styles.Resources.cat.jpg");
        }
    }
}