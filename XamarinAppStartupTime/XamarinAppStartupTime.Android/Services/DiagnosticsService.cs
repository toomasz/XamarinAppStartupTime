using System;
using System.Collections.Generic;
using XamarinAppStartupTime.Services;

namespace XamarinAppStartupTime.Droid.Services
{
    internal class DiagnosticsService : IDiagnosticsService
    {
        private static Dictionary<string, TimeSpan?> _eventTimingsSinceStartup = new Dictionary<string, TimeSpan?>();

        public static void ReportEventInternal(string eventName)
        {
            if(_eventTimingsSinceStartup.ContainsKey(eventName))
            {
                // event already occured
                return;
            }
            _eventTimingsSinceStartup.Add(eventName, DateTime.UtcNow - StartupTimeHelper.GetAppStartupTime());
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
            return eventTime.Value - StartupTimeHelper.GetAppStartupTime();
        }

        public Dictionary<string, TimeSpan?> GetTimingsSinceStartup()
        {
            return _eventTimingsSinceStartup;
        }

        public DateTime GetStartupTime()
        {
            return StartupTimeHelper.GetAppStartupTime();
        }
    }
}