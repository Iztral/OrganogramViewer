using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrganogramViewer
{
    class Program
    {
        static void Main()
        {

            List<Employee> employeeList = CSVFileParsing.LoadEmployeesFromFile();
            if (employeeList != null)
                OrganogramDisplay.DisplayOrganogram(employeeList);
            else
                Console.WriteLine("Something is wrong with the file.");
            
            WaitForClosing();
        }
        private static void WaitForClosing()
        {
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}
