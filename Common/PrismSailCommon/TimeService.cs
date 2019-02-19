using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
