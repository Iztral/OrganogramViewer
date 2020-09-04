using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OrganogramViewer;
using System.Collections.Generic;
using System.Linq;

namespace OrnanogramViewerTests
{
    [TestClass]
    public class OrnanogramTests
    {
        [TestMethod]
        public void StringParsesCorrectly()
        {
            string stringToParse = "2,1,Jackie,Smith,IBM,Johannesburg,Assistant Director,0742546877,0116725351,0116725371";
            Employee expectedEmployee = new Employee
            {
                Id = 2,
                SuperiorId = 1,
                Name = "Jackie",
                Surname = "Smith",
                Company = "IBM",
                City = "Johannesburg",
                Position = "Assistant Director"
            };
            var testedEmployee = CSVFileParsing.ParseEmployeeString(stringToParse);

            var object1Json = JsonConvert.SerializeObject(expectedEmployee);
            var object2Json = JsonConvert.SerializeObject(testedEmployee);
            Assert.AreEqual(object1Json, object2Json);
        }

        [TestMethod]
        public void GetsValidSuperior()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id = 2,
                    SuperiorId = 1,
                    Name = "Jackie",
                    Surname = "Smith",
                    Company = "IBM",
                    City = "Johannesburg",
                    Position = "Junior Analyst"
                },
                new Employee
                {
                    Id = 1,
                    SuperiorId = 0,
                    Name = "Jackie",
                    Surname = "Smith",
                    Company = "IBM",
                    City = "Johannesburg",
                    Position = "Assistant Director"
                }
            };

            var expected_superior = JsonConvert.SerializeObject(employees[1]);
            var actual_superior = JsonConvert.SerializeObject(EmployeeSearch.GetSuperior(employees, 1));

            Assert.AreEqual(expected_superior, actual_superior);

        }

        [TestMethod]
        public void GetsValidSubordinate()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id = 2,
                    SuperiorId = 1,
                    Name = "Jackie",
                    Surname = "Smith",
                    Company = "IBM",
                    City = "Johannesburg",
                    Position = "Junior Analyst"
                },
                new Employee
                {
                    Id = 1,
                    SuperiorId = 0,
                    Name = "Jackie",
                    Surname = "Smith",
                    Company = "IBM",
                    City = "Johannesburg",
                    Position = "Assistant Director"
                }
            };

            var expected_subordinate = JsonConvert.SerializeObject(employees[0]);
            var actual_subordinate = JsonConvert.SerializeObject(EmployeeSearch.GetSubordinates(employees, 1).First());

            Assert.AreEqual(expected_subordinate, actual_subordinate);
        }
    }
}
