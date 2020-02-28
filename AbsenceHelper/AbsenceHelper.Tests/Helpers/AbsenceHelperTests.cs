using AbsenceHelper.Models;

using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace AbsenceHelper.Tests.Helpers
{
    public class AbsenceHelperTests
    {
        [Fact]
        public void CanUpdateAbsenceFromXmlList()
        {
            var result = AbsenceHelper.Helpers.AbsenceHelper.UpdateAbsenceFromXml(GetAbsenceData(), GetData());

            Assert.Equal(5, result.Where(x => x.EmployeeId == 2).Count());
            Assert.Equal(6, result.Where(x => x.EmployeeId == 4).Count());
            Assert.Equal(3, result.Where(x => x.EmployeeId == 5).Count());
            Assert.Equal(new decimal(0.55), result.Where(x => x.EmployeeId == 2).FirstOrDefault().Percentage);
            Assert.Equal('A', result.Where(x => x.EmployeeId == 2).FirstOrDefault().TypeName);
            Assert.Equal(new decimal(0.75), result.Where(x => x.EmployeeId == 4).FirstOrDefault().Percentage);
            Assert.Equal('B', result.Where(x => x.EmployeeId == 4).FirstOrDefault().TypeName);
        }

        private List<AbsenceData> GetAbsenceData()
        {
            return new List<AbsenceData>
            {
                new AbsenceData
                {
                    EmployeeId = 2,
                    Date = new DateTime(2019, 03, 01),
                    Percentage = new decimal(0.45),
                    TypeName = 'A'
                },
                new AbsenceData
                {
                    EmployeeId = 2,
                    Date = new DateTime(2019, 03, 02),
                    Percentage = new decimal(0.45),
                    TypeName = 'A'
                },
                new AbsenceData
                {
                    EmployeeId = 2,
                    Date = new DateTime(2019, 03, 03),
                    Percentage = new decimal(0.45),
                    TypeName = 'A'
                },
                new AbsenceData
                {
                    EmployeeId = 2,
                    Date = new DateTime(2019, 03, 04),
                    Percentage = new decimal(0.45),
                    TypeName = 'A'
                },
                new AbsenceData
                {
                    EmployeeId = 4,
                    Date = new DateTime(2019, 03, 15),
                    Percentage = new decimal(0.75),
                    TypeName = 'B'
                },
                new AbsenceData
                {
                    EmployeeId = 4,
                    Date = new DateTime(2019, 03, 16),
                    Percentage = new decimal(0.75),
                    TypeName = 'B'
                },
                new AbsenceData
                {
                    EmployeeId = 4,
                    Date = new DateTime(2019, 03, 17),
                    Percentage = new decimal(0.75),
                    TypeName = 'B'
                },
            };
        }

        private List<Data> GetData()
        {
            return new List<Data>
            {
                new Data
                {
                    Employees = new Employee[]
                    {
                        new Employee
                        {
                            EmployeeId = "2",
                            StartDate = new DateTime(2019, 03, 01).ToString(),
                            EndDate = new DateTime(2019, 03, 15).ToString(),
                            Percentage = new decimal(0.55),
                            TypeId = "1"
                        },
                        new Employee
                        {
                            EmployeeId = "5",
                            StartDate = new DateTime(2019, 04, 01).ToString(),
                            EndDate = new DateTime(2019, 04, 03).ToString(),
                            Percentage = new decimal(0.85),
                            TypeId = "2"
                        }
                    },
                    FileDate = new DateTime(2019, 02, 25)
                },
                new Data
                {
                    Employees = new Employee[]
                    {
                        new Employee
                        {
                           EmployeeId = "2",
                            StartDate = new DateTime(2019, 03, 01).ToString(),
                            EndDate = new DateTime(2019, 03, 05).ToString(),
                            Percentage = new decimal(0.55),
                            TypeId = "1"
                        },
                        new Employee
                        {
                            EmployeeId = "4",
                            StartDate = new DateTime(2019, 03, 15).ToString(),
                            EndDate = new DateTime(2019, 03, 20).ToString(),
                            Percentage = new decimal(0.75),
                            TypeId = "3"
                        }
                    },
                    FileDate = new DateTime(2019, 03, 01)
                }
            };
        }
    }
}
