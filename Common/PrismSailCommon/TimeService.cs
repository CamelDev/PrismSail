using System;

namespace PrismSailCommon
{
    public interface ITimeService
    {
        DateTime GetTime();
    }
    public class TimeService : ITimeService
    {
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}