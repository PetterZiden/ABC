using AbsenceHelper.Helpers;
using System;
using System.Linq;

namespace AbsenceHelper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var csvList = Deserializer.GetCsvList();
            var xmlList = Deserializer.GetXmlLists();

            Console.WriteLine($".....");
        }
    }
}
