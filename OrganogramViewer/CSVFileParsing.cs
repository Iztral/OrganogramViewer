using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganogramViewer
{
    public static class CSVFileParsing
    {
        public static List<Employee> LoadEmployeesFromFile()
        {
            List<string> employeeString = LoadStringsFromCSV();
            return employeeString != null ? GetEmployesFromString(employeeString) : null;
        }

        public static List<Employee> GetEmployesFromString(List<string> employeeStrings)
        {
            return (from string employeeString in employeeStrings
                    let employee = ParseEmployeeString(employeeString)
                    where employee != null
                    select employee).ToList();
        }

        public static Employee ParseEmployeeString(string employeeString)
        {
            string[] employeeFields = employeeString.Split(',');

            try
            {
                return new Employee
                {
                    Id = int.Parse(employeeFields[0]),
                    SuperiorId = int.Parse(employeeFields[1]),
                    Name = employeeFields[2],
                    Surname = employeeFields[3],
                    Company = employeeFields[4],
                    City = employeeFields[5],
                    Position = employeeFields[6]
                };
            }
            catch
            {
                return new Employee();
            }
        }

        private static List<string> LoadStringsFromCSV()
        {
            try
            {
                Microsoft.VisualBasic.FileIO.TextFieldParser parser = new Microsoft.VisualBasic.FileIO.TextFieldParser("companies_data.csv")
                {
                    TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
                };
                parser.SetDelimiters(new string[] { ";" });

                List<string> rows = new List<string>();
                while (!parser.EndOfData)
                {
                    rows.AddRange(parser.ReadFields());
                }
                return rows;
            }
            catch (IOException)
            {
                return null;
            }
        }
    }
}
