using AbsenceHelper.Models;

using System;
using System.Linq;

using Xunit;

namespace AbsenceHelper.Tests.Mapper
{
    public class MapperTests
    {
        [Fact]
        public void CanMapStartDataToAbsenceData()
        {
            var startData = new StartData
            {
                Date = DateTime.Today.AddDays(-2).ToString(),
                EmployeeId = "2",
                Percentage = "0,55",
                TypeName = "3"
            };

            var result = AbsenceHelper.Mapper.Mapper.MapStartDataToAbsenceData(startData);

            Assert.Equal(startData.Date, result.Date.ToString());
            Assert.IsType<short>(result.EmployeeId);
            Assert.IsType<DateTime>(result.Date);
            Assert.IsType<char>(result.TypeName);
            Assert.IsType<decimal>(result.Percentage);

        }

        [Fact]
        public void CanMapEmployeeToAbsenceData()
        {
            var employee = new Employee
            {
                StartDate = DateTime.Today.AddDays(-4).ToString(),
                EndDate = DateTime.Today.AddDays(-2).ToString(),
                EmployeeId = "2",
                Percentage = new decimal(0.55),
                TypeId = "1"
            };

            var result = AbsenceHelper.Mapper.Mapper.MapEmployeeToAbsenceData(employee);

            Assert.Equal(3, result.Count());
            Assert.Equal(2, result[0].EmployeeId);
            Assert.IsType<short>(result[0].EmployeeId);
            Assert.IsType<DateTime>(result[0].Date);
            Assert.IsType<char>(result[0].TypeName);
            Assert.IsType<decimal>(result[0].Percentage);

        }
    }
}
