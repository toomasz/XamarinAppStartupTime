using System;
using System.Collections.Generic;

namespace XamarinAppStartupTime.Services
{
    public interface IDiagnosticsService
    {
        void ReportEvent(string eventName);
        Dictionary<string, TimeSpan?> GetTimingsSinceStartup();
        DateTime GetStartupTime();
    }
}
