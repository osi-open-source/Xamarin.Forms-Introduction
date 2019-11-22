using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Styles.Droid.Effects;
using Styles.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Example")]
[assembly: ExportEffect(typeof(DroidErrorEffect), nameof(ErrorEffect))]
namespace Styles.Droid.Effects
{
    public class DroidErrorEffect : PlatformEffect
    {
        Android.Graphics.Color _originalBorderColor = Android.Graphics.Color.Black;

        protected override void OnAttached()
        {
            try
            {
                var shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
                shape.Paint.Color = Xamarin.Forms.Color.Red.ToAndroid();
                shape.Paint.StrokeWidth = 3;
                shape.Paint.SetStyle(Paint.Style.Stroke);

                Control.Background = shape;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
            try
            {
                var shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
                shape.Paint.Color = _originalBorderColor;
                shape.Paint.StrokeWidth = 3;
                shape.Paint.SetStyle(Paint.Style.Stroke);

                Control.Background = shape;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }
    }
}