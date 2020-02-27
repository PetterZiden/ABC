using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using AbsenceHelper.Models;

namespace AbsenceHelper.Helpers
{
    public static class AbsenceHelper
    {
        public static List<AbsenceData> AddAbsenceFromXml(List<AbsenceData> csvList, List<Data> xmlList)
        {
            xmlList = RemoveIncorrectAbsenceFromXmlLists(xmlList);

            foreach (var xmlData in xmlList)
            {
                csvList = AddXmlListToCsvListAndUpdatePercentage(csvList, CreateAbsenceListFromXML(xmlData));
            }

            return csvList;
        }

        private static List<Data> RemoveIncorrectAbsenceFromXmlLists(List<Data> xmlList)
        {
            foreach (var old in xmlList[0].Employees)
            {
                foreach (var latest in xmlList[1].Employees)
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

            return xmlList;
        }

        private static List<AbsenceData> CreateAbsenceListFromXML(Data xmLlist)
        {
            var absenceList = new List<AbsenceData>();

            foreach (var employee in xmLlist.Employees)
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
