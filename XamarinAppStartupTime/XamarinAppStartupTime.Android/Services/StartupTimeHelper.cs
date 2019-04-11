using System;
using System.Globalization;
using Java.IO;
using Java.Lang;

namespace XamarinAppStartupTime.Droid.Services
{
    internal static class StartupTimeHelper
    {
        private static DateTime? StartupTime;
        private static bool _attemptedToGetStartupTime;
        public static DateTime? GetAppStartupTimeUtc()
        {
            if(_attemptedToGetStartupTime)
            {
                return StartupTime;
            }
            if (!StartupTime.HasValue)
            {
                StartupTime = GetStartupTimeUtcFromLogcat();
                _attemptedToGetStartupTime = true;
            }
            return StartupTime;
        }

        private static DateTime? GetStartupTimeUtcFromLogcat()
        {
            var pid = Android.OS.Process.MyPid();

            var process = new ProcessBuilder().
                RedirectErrorStream(true).
                Command("/system/bin/logcat", $"--pid={pid}", "-m", "1", "-v", "year,UTC").Start();

            using (var bufferedReader = new BufferedReader(new InputStreamReader(process.InputStream)))
            {
                string line = null;
                while ((line = bufferedReader.ReadLine()) != null)
                {
                    if (ParseLogDateTime(line, out DateTime date))
                    {
                        return date;
                    }
                }
            }

          
            return null;
        }
        const string LogcatTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";

        private static bool ParseLogDateTime(string logLine, out DateTime dateTime)
        {           
            if(logLine.Length < LogcatTimeFormat.Length)
            {
                dateTime = new DateTime();
                return false;
            }
            var timeStr = logLine.Substring(0, LogcatTimeFormat.Length);

            return DateTime.TryParseExact(timeStr, LogcatTimeFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out dateTime);
        }
    }
}