using Xamarin.Forms;
using XamarinAppStartupTime.Services;

namespace XamarinAppStartupTime
{
    public partial class App : Application
    {
        private IDiagnosticsService diagnosticsService = DependencyService.Get<IDiagnosticsService>();
        public App()
        {
            diagnosticsService.ReportEvent("XF App .ctor enter");
            InitializeComponent();
            diagnosticsService.ReportEvent("XF App .ctor exit");
        }

        protected override void OnStart()
        {
            diagnosticsService.ReportEvent("App::OnStart enter");
            MainPage = new MainPage();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
