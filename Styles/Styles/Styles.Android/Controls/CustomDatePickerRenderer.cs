using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Styles.Controls;
using Styles.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace Styles.Droid.Controls
{
    public class CustomDatePickerRenderer : ViewRenderer<CustomDatePicker, EditText>
    {
        DatePickerDialog _dialog;

        public CustomDatePickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<CustomDatePicker> e)
        {
            base.OnElementChanged(e);

            this.SetNativeControl(new EditText(Context));
            if (Control == null || e.NewElement == null)
                return;

            this.Control.Click += OnPickerClick;
            this.Control.Text = Element.Date.ToString(Element.Format);
            this.Control.KeyListener = null;
            this.Control.FocusChange += OnPickerFocusChange;
            this.Control.Enabled = Element.IsEnabled;

            this.Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            this.Control.SetPadding(20, 0, 0, 0);

            var background = new GradientDrawable();
            background.SetCornerRadius(40); //increase or decrease to changes the corner look
            background.SetColor(Android.Graphics.Color.Transparent);
            background.SetStroke(2, Android.Graphics.Color.ParseColor("#EAEAEA"));

            Background = background;

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Xamarin.Forms.DatePicker.DateProperty.PropertyName || e.PropertyName == Xamarin.Forms.DatePicker.FormatProperty.PropertyName)
                SetDate(Element.Date);
        }

        void OnPickerFocusChange(object sender, Android.Views.View.FocusChangeEventArgs e)
        {
            if (e.HasFocus && _dialog == null)
            {
                ShowDatePicker();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null)
            {
                this.Control.Click -= OnPickerClick;
                this.Control.FocusChange -= OnPickerFocusChange;

                if (_dialog != null)
                {
                    _dialog.Hide();
                    _dialog.Dispose();
                    _dialog = null;
                }
            }

            base.Dispose(disposing);
        }

        void OnPickerClick(object sender, EventArgs e)
        {
            ShowDatePicker();
        }

        void SetDate(DateTime date)
        {
            if (date <= Element.MaximumDate)
            {
                this.Control.Text = date.ToString(Element.Format);
                Element.Date = date;
            }
        }

        private void ShowDatePicker()
        {
            CreateDatePickerDialog(this.Element.Date.Year, this.Element.Date.Month - 1, this.Element.Date.Day);
            _dialog.Show();
        }

        void CreateDatePickerDialog(int year, int month, int day)
        {
            CustomDatePicker view = Element;
            _dialog = new DatePickerDialog(Context, (o, e) =>
            {
                view.Date = e.Date;
                ((IElementController)view).SetValueFromRenderer(VisualElement.IsFocusedProperty, false);
                Control.ClearFocus();

                _dialog = null;
            }, year, month, day);

            _dialog.SetButton("Done", (sender, e) =>
            {
                this.ClearFocus();
                SetDate(_dialog.DatePicker.DateTime);
                this.Element.Format = this.Element.OriginalFormat;
                this.Element.AssignValue();
                Control.Parent.RequestLayout();

                _dialog = null;
            });
            _dialog.SetButton2("Clear", (sender, e) =>
            {
                this.ClearFocus();
                this.Element.ClearDate();
                Control.Text = this.Element.PlaceHolder;
                Control.Invalidate();
                Control.RequestLayout();
                Control.ForceLayout();

                _dialog = null;
            });
        }
    }
}