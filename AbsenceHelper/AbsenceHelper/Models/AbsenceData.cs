using System;

namespace AbsenceHelper.Models
{
    public class AbsenceData
    {
        public short EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public char TypeName { get; set; }

        public decimal Percentage { get; set; }
    }
}
