using AbsenceHelper.Models;

using System.Collections.Generic;
using System.Linq;

namespace AbsenceHelper.Helpers
{
    public static class DateHelper
    {
        public static bool DateChecker(IEnumerable<AbsenceData> list, int numberOfDays)
        {
            if (list.Count() < numberOfDays)
            {
                return false;
            }

            var counter = 1;

            for (int i = 0; i < list.Count(); i++)
            {
                if (list.ElementAt(i).Date.AddDays(1) == list.ElementAt(i + 1).Date)
                {
                    counter++;
                }
                if (counter == numberOfDays)
                {
                    return true;
                }

            }

            return false; ;
        }
    }
}
