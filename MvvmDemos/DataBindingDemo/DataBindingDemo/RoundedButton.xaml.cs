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
    public partial class RoundedButton : ContentView
    {
        public RoundedButton()
        {
            InitializeComponent();
        }

        public static BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(RoundedButton));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter),
            typeof(object),
            typeof(RoundedButton),
            defaultBindingMode: BindingMode.TwoWay);

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(RoundedButton),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnTextPropertyChanged);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private void RoundedButton_Clicked(object sender, EventArgs e)
        {
            if (Command != null)
            {
                Command.Execute(CommandParameter);
            }
            
        }

        private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var roundedBtn = bindable as RoundedButton;
            if (roundedBtn != null)
            {
                roundedBtn.InnerButton.Text = newValue as string;
            }
        }
    }
}