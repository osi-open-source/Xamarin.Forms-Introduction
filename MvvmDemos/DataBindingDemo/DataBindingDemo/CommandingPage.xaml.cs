using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataBindingDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommandingPage : ContentPage
    {
        private ICommand _textChangedCommand;
        private string _text;
        private ICommand _openDialogCommand;
        private ICommand _replaceLabelCommand;

        public CommandingPage()
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

        public ICommand TextChangedCommand => _textChangedCommand ?? (_textChangedCommand = new Command<string>((newText) =>
        {
            if (newText.Contains(" "))
            {
                Text = newText.Replace(" ", string.Empty);
            }
        }));

        public ICommand OpenDialogCommand => _openDialogCommand ?? (_openDialogCommand = new Command<string>(async (text) =>
        {
            if (!string.IsNullOrEmpty(text))
            {
                await DisplayAlert("Custom message", text, "Wow!");
            }
            else
            {
                await DisplayAlert("A Dialog", "This is a dialog", "Really?");
            }
        }));

        public ICommand ReplaceLabelCommand => _replaceLabelCommand ?? (_replaceLabelCommand = new Command<string>((text) =>
        {
            Text = text;
        }));

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}