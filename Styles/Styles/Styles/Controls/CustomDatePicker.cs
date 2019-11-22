using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Styles.Controls
{
    public class CustomDatePicker : DatePicker
    {
        public CustomDatePicker()
        {
            Format = "yyyy/MM/dd";
            MaximumDate = DateTime.Now;
        }

        public static readonly BindableProperty PlaceHolderProperty =
            BindableProperty.Create(nameof(PlaceHolder), typeof(string), typeof(CustomDatePicker), " ----  /  --  /  -- ");

        public static readonly BindableProperty NullableDateProperty =
        BindableProperty.Create(nameof(NullableDate), typeof(DateTime?), typeof(CustomDatePicker), null, defaultBindingMode: BindingMode.TwoWay);

        public string OriginalFormat = null;

        public string PlaceHolder
        {
            get => (string)GetValue(PlaceHolderProperty);
            set => SetValue(PlaceHolderProperty, value);
        }

        public DateTime? NullableDate
        {
            get => (DateTime?)GetValue(NullableDateProperty);
            set
            {
                SetValue(NullableDateProperty, value);
                UpdateDate();
            }
        }

        public void ClearDate()
        {
            NullableDate = null;
            UpdateDate();
        }

        public void AssignValue()
        {
            NullableDate = Date;
            UpdateDate();

        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext != null)
            {
                OriginalFormat = Format;
                UpdateDate();
            }
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == DateProperty.PropertyName || (propertyName == IsFocusedProperty.PropertyName && !IsFocused && (Date.ToString("yyyy/MM/dd") == DateTime.Now.ToString("yyyy/MM/dd"))))
            {
                AssignValue();
            }

            if (propertyName == NullableDateProperty.PropertyName && NullableDate.HasValue)
            {
                if (Date != NullableDate.Value)
                {
                    Date = NullableDate.Value;
                }

                if (Date.ToString(OriginalFormat) == DateTime.Now.ToString(OriginalFormat))
                {
                    //this code was done because when date selected is the actual date the "DateProperty" does not raise  
                    UpdateDate();
                }
            }
        }

        private void UpdateDate()
        {
            if (NullableDate != null)
            {
                if (OriginalFormat != null)
                {
                    Format = OriginalFormat;
                }
            }
            else
            {
                Format = PlaceHolder;
            }
        }
    }
}
