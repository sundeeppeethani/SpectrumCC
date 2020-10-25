using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace SpectrumCC.Droid.Views
{
    [Activity(Label = "MainViewModel")]
    public class MainView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);
        }
    }
}
