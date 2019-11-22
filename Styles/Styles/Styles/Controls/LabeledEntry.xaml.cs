using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Styles.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabeledEntry : ContentView
    {
        public LabeledEntry()
        {
            InitializeComponent();
        }

        public static BindableProperty DescriptionProperty = BindableProperty.Create(
            nameof(Description),
            typeof(string),
            typeof(LabeledEntry),
            string.Empty,
            propertyChanged: DescriptionPropertyChanged);

        public static BindableProperty ValueProperty = BindableProperty.Create(
            nameof(Value),
            typeof(string),
            typeof(LabeledEntry),
            string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ValuePropertyChanged);

        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        private static void DescriptionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ExecutePropertyChangedAction(bindable, (labeledEntry) =>
            {
                labeledEntry.DescriptionLabel.Text = newValue as string;
            });
        }

        private static void ValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ExecutePropertyChangedAction(bindable, (labeledEntry) =>
            {
                labeledEntry.ValueEntry.Text = newValue as string;
            });
        }

        private void ValueEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Value = e.NewTextValue;
        }

        private static void ExecutePropertyChangedAction(BindableObject bindable, Action<LabeledEntry> action)
        {
            var labeledEntry = bindable as LabeledEntry;
            if (labeledEntry != null)
            {
                action.Invoke(labeledEntry);
            }
        }
    }
}