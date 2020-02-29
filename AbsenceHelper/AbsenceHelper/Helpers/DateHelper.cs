using AbsenceHelper.Models;

using System.Collections.Generic;
using System.Linq;

namespace AbsenceHelper.Helpers
{
    public static class DateHelper
    {
        public static bool SequentialDateValidation(IEnumerable<AbsenceData> list, int numberOfDays)
        {
            if (list.Count() < numberOfDays)
            {
                return false;
            }

            var counter = 1;

            for (var i = 0; i < list.Count() - 1; i++)
            {
                if (list.ElementAt(i).Date.AddDays(1) == list.ElementAt(i + 1).Date)
                {
                    counter++;
                }
                else
                {
                    counter = 1;
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
