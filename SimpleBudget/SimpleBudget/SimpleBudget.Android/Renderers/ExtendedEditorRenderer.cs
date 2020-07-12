using System;
using Android.Graphics.Drawables;
using SimpleBudget.Droid.Listeners;
using SimpleBudget.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Editor), typeof(ExtendedEditorRenderer))]

namespace SimpleBudget.Droid.Renderers
{
    [Obsolete]
    public class ExtendedEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            var shape = new GradientDrawable();
            shape.SetColor(Android.Graphics.Color.Transparent);
            shape.SetCornerRadius(10);
            shape.SetStroke(2, Android.Graphics.Color.White);
            Control.SetBackgroundDrawable(shape);

            Control.SetPadding(15,8,8,8);

            if (e.OldElement == null)
            {
                var nativeEditText = (global::Android.Widget.EditText)Control;
                nativeEditText.OverScrollMode = Android.Views.OverScrollMode.Always;
                nativeEditText.ScrollBarStyle = Android.Views.ScrollbarStyles.InsideInset;
                nativeEditText.SetOnTouchListener(new DroidTouchListener());
            }
        }
    }
}