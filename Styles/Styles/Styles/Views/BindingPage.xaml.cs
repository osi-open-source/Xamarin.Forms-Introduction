using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Styles.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BindingPage : ContentPage
    {
        private int _counter;
        private string _text;

        public BindingPage()
        {
            InitializeComponent();
            BindingContext = this;
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

        public ICommand ButtonClickCommand => new Command(() =>
        {
            Counter++;
        });

        public int Counter
        {
            get => _counter;
            private set
            {
                _counter = value;
                OnPropertyChanged();
            }
        }

        public DateTime? Date { get; set; }
    }
}