using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinAppStartupTime.Services;

namespace XamarinAppStartupTime.Droid.Services
{
    internal class DiagnosticsService : IDiagnosticsService
    {
        private static Dictionary<string, DateTime?> _eventTimingsSinceStartup = new Dictionary<string, DateTime?>();

        public static void ReportEventInternal(string eventName)
        {
            if(_eventTimingsSinceStartup.ContainsKey(eventName))
            {
                // event already occured
                return;
            }
            
            _eventTimingsSinceStartup.Add(eventName, DateTime.UtcNow);
        }

        public void ReportEvent(string eventName)
        {
            ReportEventInternal(eventName);
        }

        private TimeSpan? GetTimeSinceStartup(DateTime? eventTime)
        {
            if (!eventTime.HasValue)
            {
                return null;
            }
            return eventTime.Value - StartupTimeHelper.GetAppStartupTimeUtc();
        }

        public async Task<Dictionary<string, TimeSpan?>> GetTimingsSinceStartup()
        {
            return await Task.Factory.StartNew(() =>
            {
                var timings = new Dictionary<string, TimeSpan?>();
                var startupTime = StartupTimeHelper.GetAppStartupTimeUtc();
                foreach (var eventInfo in _eventTimingsSinceStartup)
                {
                    timings.Add(eventInfo.Key, eventInfo.Value - startupTime);
                }
                return timings;
            });
           
        }

        public DateTime? GetStartupTime()
        {
            return StartupTimeHelper.GetAppStartupTimeUtc();
        }
    }
}