using AbsenceHelper.Models;

using System;

namespace AbsenceHelper.Mapper
{
    public static class Mapper
    {
        public static AbsenceData MapStartDataToAbsenceData(StartData startData)
        {
            return new AbsenceData
            {
                EmployeeId = Int16.Parse(startData.EmployeeId),
                Date = Convert.ToDateTime(startData.Date),
                TypeName = startData.TypeName == ("1") ? char.Parse("A") : char.Parse("B"),
                Percentage = decimal.Parse(startData.Percentage)
            };
        }
    }
}
