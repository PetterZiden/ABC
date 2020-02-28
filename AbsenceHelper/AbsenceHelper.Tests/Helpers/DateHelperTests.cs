using AbsenceHelper.Models;

using System;
using System.Collections.Generic;

using Xunit;

namespace AbsenceHelper.Tests.Helpers
{
    public class DateHelperTests
    {
        [Theory]
        [InlineData("2019-03-01", "2019-03-02", "2019-03-03", "2019-03-04", "2019-03-05", 5, true)]
        [InlineData("2019-03-01", "2019-03-02", "2019-03-05", "2019-03-06", "2019-03-07", 3, true)]
        [InlineData("2019-03-01", "2019-03-02", "2019-03-03", "2019-03-04", "2019-03-05", 6, false)]
        [InlineData("2019-03-01", "2019-03-02", "2019-03-04", "2019-03-05", "2019-03-06", 5, false)]
        public void CanCheckIfDatesAreSequential(
            string date1,
            string date2,
            string date3,
            string date4,
            string date5,
            int numberOfDays,
            bool expectedResult)
        {
            var absenceList = GetAbsenceData(date1, date2, date3, date4, date5);

            var result = AbsenceHelper.Helpers.DateHelper.SequentialDateValidation(absenceList, numberOfDays);

            Assert.Equal(expectedResult, result);
        }

        private IEnumerable<AbsenceData> GetAbsenceData(
            string date1,
            string date2,
            string date3,
            string date4,
            string date5)
        {
            return new List<AbsenceData>
            {
                 new AbsenceData
                {
                    EmployeeId = 2,
                    Date = Convert.ToDateTime(date1),
                    Percentage = new decimal(0.45),
                    TypeName = 'A'
                },
                new AbsenceData
                {
                    EmployeeId = 2,
                    Date = Convert.ToDateTime(date2),
                    Percentage = new decimal(0.45),
                    TypeName = 'A'
                },
                new AbsenceData
                {
                    EmployeeId = 2,
                    Date = Convert.ToDateTime(date3),
                    Percentage = new decimal(0.45),
                    TypeName = 'A'
                },
                new AbsenceData
                {
                    EmployeeId = 2,
                    Date = Convert.ToDateTime(date4),
                    Percentage = new decimal(0.45),
                    TypeName = 'A'
                },
                new AbsenceData
                {
                    EmployeeId = 2,
                    Date = Convert.ToDateTime(date5),
                    Percentage = new decimal(0.45),
                    TypeName = 'A'
                },
            };
        }
    }
}
