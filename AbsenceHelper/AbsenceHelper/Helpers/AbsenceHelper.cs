using System;
using System.Collections.Generic;
using System.Linq;
using AbsenceHelper.Models;

namespace AbsenceHelper.Helpers
{
    public static class AbsenceHelper
    {
        public static List<AbsenceData> AddAbsenceFromXml(List<AbsenceData> csvList, List<Data> xmlList)
        {
            xmlList = RemoveIncorrectAbsenceFromXmlLists(xmlList);

            var firstXmlAbsenceList = CreateAbsenceListFromXML(xmlList[0]);
            var secondXmlAbsenceList = CreateAbsenceListFromXML(xmlList[1]);

            csvList = AddXmlListToCsvListAndUpdatePercentage(csvList, firstXmlAbsenceList);
            csvList = AddXmlListToCsvListAndUpdatePercentage(csvList, secondXmlAbsenceList);

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
            // !?!!!??!?!?!?!
            var tempList = xmlList.Where(x => csvList.Any(y => y.EmployeeId == x.EmployeeId));

            return csvList;
        }

      
    }
}
