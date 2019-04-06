using System;
using XamarinAppStartupTime.Helpers;

namespace XamarinAppStartupTime.ViewModels
{
    class TimingItemViewModel
    {
        public TimingItemViewModel(string eventName, TimeSpan? elapsedTime)
        {
            EventCaption = eventName;
            ElapsedTime = elapsedTime.ToCanonicString();
        }

        public string EventCaption { get; }
        public string ElapsedTime { get; }
    }
}
