using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganogramViewer
{
    public class OrganogramDisplay
    {
        //in case of addidtional content beside employees to display in organogram//
        public static void DisplayOrganogram(List<Employee> allEmployees)
        {
            DisplayAllEmployees(allEmployees);
        }

        public static void DisplayAllEmployees(List<Employee> allEmployees)
        {
            foreach (Employee superior in EmployeeSearch.GetTopSuperiors(allEmployees))
            {
                DisplayEmployee(allEmployees, superior, 0);
                Console.WriteLine("\n");
            }
        }

        public static void DisplayEmployee(List<Employee> allEmployees, Employee employeeToDisplay, int depth)
        {
            if (!(employeeToDisplay is null))
            {
                Console.WriteLine(GetPreparedStringToDisplay(employeeToDisplay, depth));
                foreach (var subordinate in EmployeeSearch.GetSubordinates(allEmployees, employeeToDisplay.Id))
                {
                    DisplayEmployee(allEmployees, subordinate, depth + 1);
                }
            }
        }

        // stringbuilder used to not waste resources//
        public static string GetPreparedStringToDisplay(Employee employeeToDisplay, int depth)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (depth > 1)
                stringBuilder.Append(string.Concat(Enumerable.Repeat("\t", depth - 1)));
            if (depth > 0)
                stringBuilder.Append("--> ");

            stringBuilder.Append(employeeToDisplay.GetGetFullName() + ", " + employeeToDisplay.Company + ", " + employeeToDisplay.Position);

            return stringBuilder.ToString();
        }
    }
}
