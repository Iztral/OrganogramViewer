using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganogramViewer
{
    public static class EmployeeSearch
    {
        //get all emplyees that don't have superiors//
        public static List<Employee> GetTopSuperiors(List<Employee> allEmployees)
        {
            return (from employee in allEmployees
                    where GetSuperior(allEmployees, employee.SuperiorId) == null
                    select employee).OrderBy(employee => employee.Id).ToList();
        }

        //returns superior for employee, return null if no superior//
        public static Employee GetSuperior(List<Employee> allEmployees, int superiorId)
        {
            return (from employee in allEmployees
                    where employee.Id == superiorId
                    select employee).FirstOrDefault();
        }

        //returns all subordinates from superior, returns null if no subordinates//
        public static List<Employee> GetSubordinates(List<Employee> allEmployees, int superiorId)
        {
            return (from employee in allEmployees
                    where employee.SuperiorId == superiorId
                    select employee).OrderBy(employee => employee.Id).ToList();
        }
    }
}
