using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinAppStartupTime.Services
{
    public interface IDiagnosticsService
    {
        void ReportEvent(string eventName);
        Task<Dictionary<string, TimeSpan?>> GetTimingsSinceStartup();
        DateTime? GetStartupTime();

        int GetPid();
    }
}
