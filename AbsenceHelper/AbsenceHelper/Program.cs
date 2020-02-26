using AbsenceHelper.Helpers;

using System;

namespace AbsenceHelper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var csvList = Deserializer.GetCsvList();
            var xmlList = Deserializer.GetXmlLists();

            // TEST
            Console.WriteLine($"Number of entities: {csvList.Count}");
            foreach (var item in csvList)
            {
                Console.WriteLine($"EmployeeId: {item.EmployeeId}, Date: {item.Date}, Type: {item.TypeName}, Percentage: {item.Percentage}");
            }
            // TEST

            csvList = Helpers.AbsenceHelper.AddAbsenceFromXml(csvList, xmlList);
            Console.WriteLine($".....");
            Console.WriteLine($".....");
            Console.WriteLine($".....");
            Console.WriteLine($".....");
            // TEST
            Console.WriteLine($"Number of entities: {csvList.Count}");
            foreach (var item in csvList)
            {
                Console.WriteLine($"EmployeeId: {item.EmployeeId}, Date: {item.Date}, Type: {item.TypeName}, Percentage: {item.Percentage}");
            }
            // TEST

            Console.WriteLine($".....");
        }
    }
}
