using AbsenceHelper.Helpers;
using System;

namespace AbsenceHelper
{
    public class Program
    {
        public static void Main()
        {
            // Retrieve and update CsvList
            var csvList = Helpers.AbsenceHelper.UpdateAbsenceFromXml(Deserializer.GetCsvList(), Deserializer.GetXmlLists());

            ReportHelper.PrintReport1(csvList);
            ReportHelper.PrintReport2(csvList);
            ReportHelper.PrintReport3(csvList);
        }
    }
}
