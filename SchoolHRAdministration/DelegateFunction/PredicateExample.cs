using HRAdminstrationAPI.FactoryPattern;

namespace SchoolHRAdministration.DelegateFunction
{
    public class PredicateExample(List<IEmployee> employees)
    {
        public void PrintEmployees()
        {
            Console.WriteLine("All Employees");
            PrintEmployee(employees);
            Console.WriteLine("\nEmployees in IT Department:");
            List<IEmployee> itEmployees = FilterEmployees(employees, emp => emp.FirstName == "Jaeson");
            PrintEmployee(itEmployees);

            Console.WriteLine("\nEmployees with Salary > 60,000:");
            List<IEmployee> highSalaryEmployees = FilterEmployees(employees, emp => emp.Salary > 60000);
            PrintEmployee(highSalaryEmployees);
        }

        private static void PrintEmployee(List<IEmployee> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }
        }

        private static List<IEmployee> FilterEmployees(List<IEmployee> employees, Predicate<IEmployee> condition)
        {
            return employees.FindAll(condition);
        }
    }
}
