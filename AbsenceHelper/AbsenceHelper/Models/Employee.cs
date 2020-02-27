using System;
using System.Xml.Serialization;

namespace AbsenceHelper.Models
{
    [Serializable]
    public class Employee
    {
        [XmlAttribute("EmployeeId")]
        public string EmployeeId { get; set; }

        [XmlElement("StartDate")]
        public string StartDate { get; set; }

        [XmlElement("EndDate")]
        public string EndDate { get; set; }

        [XmlElement("TypeId")]
        public string TypeId { get; set; }

        [XmlElement("Percentage")]
        public decimal Percentage { get; set; }
    }
}
