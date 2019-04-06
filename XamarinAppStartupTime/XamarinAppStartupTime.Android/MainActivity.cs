using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using XamarinAppStartupTime.Droid.Services;

namespace XamarinAppStartupTime.Droid
{
    [Activity(Label = "XamarinAppStartupTime", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public MainActivity()
        {
            DiagnosticsService.ReportEventInternal("MainActivity .ctor");
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            DiagnosticsService.ReportEventInternal("MainActivity OnCreate enter");

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Forms.SetFlags("FastRenderers_Experimental", "CollectionView_Experimental");

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);

            DependencyService.Register<DiagnosticsService>();

            LoadApplication(new App());

            DiagnosticsService.ReportEventInternal("MainActivity OnCreate exit");
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}