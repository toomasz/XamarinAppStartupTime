using System;
using System.Collections.Generic;
using System.Linq;
using XamarinAppStartupTime.Services;

namespace XamarinAppStartupTime.ViewModels
{
    internal class MainViewModel
    {
        public MainViewModel(IDiagnosticsService diagnosticsService)
        {

            Timings = diagnosticsService
                .GetTimingsSinceStartup()
                .Select(t => new TimingItemViewModel(t.Key, t.Value))
                .ToList();
            StartupTime = diagnosticsService.GetStartupTime().ToLocalTime();
        }
        public DateTime StartupTime { get; }
        public List<TimingItemViewModel> Timings { get; }
    }
}
