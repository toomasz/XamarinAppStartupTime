using System.ComponentModel;
using Xamarin.Forms;
using XamarinAppStartupTime.Services;
using XamarinAppStartupTime.ViewModels;

namespace XamarinAppStartupTime
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(DependencyService.Get<IDiagnosticsService>());
        }
    }
}
