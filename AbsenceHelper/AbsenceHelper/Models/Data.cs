using System;
using System.Xml.Serialization;

namespace AbsenceHelper.Models
{
    [Serializable]
    public class Data
    {
        [XmlElement("FileDate")]
        public DateTime FileDate { get; set; }

        [XmlArray("Employees")]
        [XmlArrayItem("Employee", typeof(Employee))]
        public Employee[] Employees { get; set; }
    }
}
