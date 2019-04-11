using System;
using System.Collections.Generic;
using System.Linq;
using XamarinAppStartupTime.Services;

namespace XamarinAppStartupTime.ViewModels
{
    internal class MainViewModel: ViewModelBase
    {
        private readonly IDiagnosticsService _diagnosticsService;

        public MainViewModel(IDiagnosticsService diagnosticsService)
        {
            _diagnosticsService = diagnosticsService;
        }

        public async void OnAppeared()
        {
            var timings =  await _diagnosticsService.GetTimingsSinceStartup();
            Timings = timings
                .Select(t => new TimingItemViewModel(t.Key, t.Value))
                .ToList();
            StartupTime = _diagnosticsService.GetStartupTime()?.ToLocalTime().ToString() ?? "-";
        }
        private string _startupTime;
        public string StartupTime
        {
            get => _startupTime;
            set => Set(ref _startupTime, value);
        }
        private List<TimingItemViewModel> _timings;
        public List<TimingItemViewModel> Timings
        {
            get => _timings;
            set => Set(ref _timings, value);
        }
    }
}
