using AbsenceHelper.Models;

using System;
using System.Collections.Generic;

namespace AbsenceHelper.Mapper
{
    public static class Mapper
    {
        public static AbsenceData MapStartDataToAbsenceData(StartData startData)
        {
            return new AbsenceData
            {
                EmployeeId = short.Parse(startData.EmployeeId),
                Date = Convert.ToDateTime(startData.Date),
                TypeName = startData.TypeName == "1" ? char.Parse("A") : char.Parse("B"),
                Percentage = decimal.Parse(startData.Percentage)
            };
        }

        public static List<AbsenceData> MapEmployeeToAbsenceData(Employee employee)
        {
            var absenceList = new List<AbsenceData>();
            var numberOfDays = Convert.ToDateTime(employee.EndDate) - Convert.ToDateTime(employee.StartDate).AddDays(-1);

            for (int i = 0; i < numberOfDays.Days; i++)
            {
                var absence = new AbsenceData
                {
                    EmployeeId = short.Parse(employee.EmployeeId),
                    Date = Convert.ToDateTime(employee.StartDate).AddDays(i),
                    Percentage = employee.Percentage,
                    TypeName = employee.TypeId == "1" ? char.Parse("A") : char.Parse("B")
                };

                absenceList.Add(absence);
            }

            return absenceList;
        }
    }
}
