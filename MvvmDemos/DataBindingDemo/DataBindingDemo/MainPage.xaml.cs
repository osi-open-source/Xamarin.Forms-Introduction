using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DataBindingDemo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private string _text;
        private string _twoWayText;
        private ICommand _clearTextCommand;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            Text = "Some default bound text";
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public string TwoWayText
        {
            get => _twoWayText;
            set
            {
                _twoWayText = value;
                OnPropertyChanged();
            }
        }

        public ICommand ClearTextCommand => _clearTextCommand ?? (_clearTextCommand = new Command(ExecuteClearText));

        private void ExecuteClearText(object obj)
        {
            Text = string.Empty;
            TwoWayText = string.Empty;
        }
    }
}
