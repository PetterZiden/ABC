using AbsenceHelper.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace AbsenceHelper.Helpers
{
    public static class ReportHelper
    {
        public static void PrintReport1(List<AbsenceData> csvList)
        {
            Console.WriteLine(Environment.NewLine + "................................................" + Environment.NewLine);
            Console.WriteLine($"Vilka anställnings-id:n är frånvarande någon gång under mars månad med minst 85% frånvaro?");

            var report = csvList.Where(p => p.Percentage >= new decimal(0.85) && p.Date.Month == 3).Select(c => c.EmployeeId).Distinct();

            foreach (var employeeId in report)
            {
                Console.WriteLine($"    - Anställnings-id: {employeeId}");
            }
        }

        public static void PrintReport2(List<AbsenceData> csvList)
        {
            Console.WriteLine(Environment.NewLine + "................................................" + Environment.NewLine);
            Console.WriteLine($"Hur många anställda är frånvarande någon gång under mars med frånvarotyp A?");

            var report = csvList.Where(p => p.TypeName.Equals('A') && p.Date.Month == 3).Select(c => c.EmployeeId).Distinct().Count();

            Console.WriteLine($"    - {report} anställda var frånvarande under denna period" + Environment.NewLine);
        }

        public static void PrintReport3(List<AbsenceData> csvList)
        {
            Console.WriteLine(Environment.NewLine + "................................................" + Environment.NewLine);

            Console.WriteLine($"Hur många anställda har en sammanhängande frånvaro om minst 5 dagar under april oavsett typ och procent?");

            var report = csvList.Where(p => p.Date.Month == 4).GroupBy(c => c.EmployeeId).Where(a => DateHelper.SequentialDateValidation(a.Select(b => b), 5)).Count();

            Console.WriteLine($"    - {report} anställda hade minst 5 dagar sammanhängande frånvaro under denna period" + Environment.NewLine);

            Console.WriteLine(Environment.NewLine + "................................................" + Environment.NewLine);
        }
    }
}
