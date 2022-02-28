using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealisticDependencies.Provider
{
    interface IDateTimeProvider
    {
        public DateTime CurrentUtc();

        public bool IsMorning();

        public bool IsAfternoon();

        public bool IsEvening();
        public bool IsLateNightEarlyMorning();


    }
}
