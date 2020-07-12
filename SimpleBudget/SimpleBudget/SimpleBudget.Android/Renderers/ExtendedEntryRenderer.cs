using System;
using Android.Graphics.Drawables;
using SimpleBudget.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(ExtendedEntryRenderer))]

namespace SimpleBudget.Droid.Renderers
{
    [Obsolete]
    public class ExtendedEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var shape = new GradientDrawable();
            shape.SetColor(Android.Graphics.Color.Transparent);
            shape.SetCornerRadius(10);
            shape.SetStroke(2, Android.Graphics.Color.White);
            Control.SetBackgroundDrawable(shape);
        }
    }
}