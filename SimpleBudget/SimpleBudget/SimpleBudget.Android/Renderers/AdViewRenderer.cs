using Android.Gms.Ads;
using Android.Widget;
using SimpleBudget.Admob;
using SimpleBudget.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AdControlView), typeof(AdViewRenderer))]

namespace SimpleBudget.Droid.Renderers
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class AdViewRenderer : ViewRenderer<Admob.AdControlView, AdView>
    {
        private string _adUnitId = "ca-app-pub-6807199856579105/2320763276";
        private AdSize _adSize = AdSize.SmartBanner;
        private AdView _adView;

        private AdView CreateNativeAdControl()
        {
            if (_adView != null)
                return _adView;

            // This is a string in the Resources/values/strings.xml that I added or you can modify it here. This comes from admob and contains a / in it
            //adUnitId = Forms.Context.Resources.GetString(Resource.String.banner_ad_unit_id);

            _adView = new AdView(Android.App.Application.Context);
            _adView.AdSize = _adSize;
            _adView.AdUnitId = _adUnitId;

            var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            _adView.LayoutParameters = adParams;

            var builder = new AdRequest.Builder();
#if DEBUG
            builder.AddTestDevice("9E07835511290AFB8BC1953CCF608168");
#endif
            _adView.LoadAd(builder.Build());

            return _adView;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Admob.AdControlView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                CreateNativeAdControl();
                SetNativeControl(_adView);
            }
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}

//#if DEBUG
//    adView.AdUnitId = "ca-app-pub-3940256099942544/6300978111"; // Google test ad id
//#else
//    adView.AdUnitId = "ca-app-pub-9709474078198381/5265548860";
//#endif