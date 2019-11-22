using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Styles.Controls;
using Styles.iOS.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace Styles.iOS.Controls
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        //protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        //{
        //    base.OnElementChanged(e);
        //    if (this.Control == null)
        //    {
        //        return;
        //    }

        //    Control.BorderStyle = UITextBorderStyle.RoundedRect;
        //    Control.Layer.BorderColor = new UIColor(red: 0.92f, green: 0.92f, blue: 0.92f, alpha: 1.0f).CGColor;   
        //    Control.Layer.CornerRadius = 10;
        //    Control.Layer.BorderWidth = 1f; 
        //}

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && this.Control != null)
            {
                this.AddClearButton();

                this.Control.BorderStyle = UITextBorderStyle.None;
                Control.Layer.BorderWidth = 0;

                Control.BorderStyle = UITextBorderStyle.RoundedRect;
                Control.Layer.BorderColor = new UIColor(red: 0.92f, green: 0.92f, blue: 0.92f, alpha: 1.0f).CGColor;
                Control.Layer.CornerRadius = 10;
                Control.Layer.BorderWidth = 1f;

                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    this.Control.Font = UIFont.SystemFontOfSize(25);
                }
            }
        }

        private void AddClearButton()
        {
            var originalToolbar = this.Control.InputAccessoryView as UIToolbar;

            if (originalToolbar != null && originalToolbar.Items.Length <= 2)
            {
                var clearButton = new UIBarButtonItem("Clear", UIBarButtonItemStyle.Plain, ((sender, ev) =>
                {
                    CustomDatePicker baseDatePicker = this.Element as CustomDatePicker;
                    this.Element.Unfocus();
                    this.Element.Date = DateTime.Now;
                    baseDatePicker.ClearDate();

                }));

                var newItems = new List<UIBarButtonItem>();
                foreach (var item in originalToolbar.Items)
                {
                    newItems.Add(item);
                }

                newItems.Insert(0, clearButton);

                originalToolbar.Items = newItems.ToArray();
                originalToolbar.SetNeedsDisplay();
            }
        }
    }
}