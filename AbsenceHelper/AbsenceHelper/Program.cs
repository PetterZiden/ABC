﻿using AbsenceHelper.Helpers;

using System;
using System.Linq;

namespace AbsenceHelper
{
    public class Program
    {
        public static void Main()
        {
            // Retrieve and update CsvList
            var csvList = Helpers.AbsenceHelper.UpdateAbsenceFromXml(Deserializer.GetCsvList(), Deserializer.GetXmlLists());

            Console.WriteLine(Environment.NewLine + "................................................" + Environment.NewLine);

            // Report 1
            Console.WriteLine($"Vilka anställnings-id:n är frånvarande någon gång under mars månad med minst 85% frånvaro?");

            var report1 = csvList.Where(p => p.Percentage >= new decimal(0.85) && p.Date.Month == 3).Select(c => c.EmployeeId).Distinct();

            foreach (var employeeId in report1)
            {
                Console.WriteLine($"    - Anställnings-id: {employeeId}");
            }

            Console.WriteLine(Environment.NewLine + "................................................" + Environment.NewLine);

            // Report 2
            Console.WriteLine($"Hur många anställda är frånvarande någon gång under mars med frånvarotyp A?");

            var report2 = csvList.Where(p => p.TypeName.Equals('A') && p.Date.Month == 3).Select(c => c.EmployeeId).Distinct().Count();

            Console.WriteLine($"    - {report2} anställda var frånvarande under denna period" + Environment.NewLine);

            Console.WriteLine(Environment.NewLine + "................................................" + Environment.NewLine);

            // Report 3
            Console.WriteLine($"Hur många anställda har en sammanhängande frånvaro om minst 5 dagar under april oavsett typ och procent?");

            var report3 = csvList.Where(p => p.Date.Month == 4).GroupBy(c => c.EmployeeId).Where(a => DateHelper.DateChecker(a.Select(b => b), 5)).Count();

            Console.WriteLine($"    - {report3} anställda hade minst 5 dagar sammanhängande frånvaro under denna period" + Environment.NewLine);

            Console.WriteLine(Environment.NewLine + "................................................" + Environment.NewLine);
        }
    }
}
