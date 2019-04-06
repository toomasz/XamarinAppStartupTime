using System;
using Android.Runtime;

namespace XamarinAppStartupTime.Droid.Services
{
    internal static class StartupTimeHelper
    {
        private static DateTime? StartupTime;
        public static DateTime GetAppStartupTime()
        {
            if (!StartupTime.HasValue)
            {
                StartupTime = GetNativeStartupTime();
            }
            return StartupTime.Value;
        }

        private static DateTime GetNativeStartupTime()
        {
            var classHandle = IntPtr.Zero;
            var theClass = JNIEnv.FindClass("com.my.contentproviders/DiagnosticContentProvider", ref classHandle);
            var theMethod = JNIEnv.GetStaticMethodID(theClass, "GetStartupTime", "()Ljava/util/Date;");

            var methodResult = JNIEnv.CallStaticObjectMethod(classHandle, theMethod);
            using (var javaStartupTime = Java.Lang.Object.GetObject<Java.Util.Date>(methodResult, JniHandleOwnership.TransferLocalRef))
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var statupTimeClr = epoch.AddMilliseconds(javaStartupTime.Time);
                return statupTimeClr;
            }
        }
    }
}