using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using SimpleBudget.Controls;
using SimpleBudget.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedButton), typeof(ExtendedButtonRenderer))]

namespace SimpleBudget.Droid.Renderers
{
    [Obsolete]
    public class ExtendedButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            var nativeElement = Element as ExtendedButton;
            if (nativeElement != null)
            {
                if (nativeElement.TintColor != Xamarin.Forms.Color.Default)
                {
                    this.Control.Background.SetColorFilter(nativeElement.TintColor.ToAndroid(), PorterDuff.Mode.Src);
                }
            }
        }
    }
}