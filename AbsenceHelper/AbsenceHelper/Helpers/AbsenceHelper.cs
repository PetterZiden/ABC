using System;
using System.Collections.Generic;
using System.Linq;

using AbsenceHelper.Models;

namespace AbsenceHelper.Helpers
{
    public static class AbsenceHelper
    {
        public static List<AbsenceData> UpdateAbsenceFromXml(List<AbsenceData> csvList, List<Data> xmlList)
        {
            for (int i = 0; i < xmlList.Count() - 1; i++)
            {
                xmlList[i] = RemoveIncorrectAbsenceFromXmlLists(xmlList[i], xmlList[i + 1]);
            }
            
            foreach (var xmlData in xmlList)
            {
                csvList = AddXmlListToCsvListAndUpdatePercentage(csvList, CreateAbsenceListFromXml(xmlData));
            }

            return csvList;
        }

        private static Data RemoveIncorrectAbsenceFromXmlLists(Data firstXmlList, Data secondXmlList)
        {
            foreach (var old in firstXmlList.Employees)
            {
                foreach (var latest in secondXmlList.Employees)
                {
                    if (old.EmployeeId == latest.EmployeeId)
                    {
                        if (Convert.ToDateTime(old.EndDate) > Convert.ToDateTime(latest.EndDate))
                        {
                            old.EndDate = latest.EndDate;
                        }
                    }
                }
            }

            return firstXmlList;
        }

        private static List<AbsenceData> CreateAbsenceListFromXml(Data xmlList)
        {
            var absenceList = new List<AbsenceData>();

            foreach (var employee in xmlList.Employees)
            {
                absenceList.AddRange(Mapper.Mapper.MapEmployeeToAbsenceData(employee));
            }

            return absenceList;
        }

        private static List<AbsenceData> AddXmlListToCsvListAndUpdatePercentage(List<AbsenceData> csvList, List<AbsenceData> xmlList)
        {
            // Add absence for new employee and dates for existing employees
            csvList.AddRange(xmlList.Where(x => !csvList.Any(c => c.EmployeeId == x.EmployeeId && c.Date == x.Date)));

            // Update percentage from xmlList
            foreach (var x in xmlList)
            {
                foreach (var c in csvList.Where(c => c.EmployeeId == x.EmployeeId && c.Date == x.Date && c.Percentage != x.Percentage))
                {
                    c.Percentage = x.Percentage;
                }
            }

            return csvList;
        }
    }
}
