using HRAdminstrationAPI;

namespace SchoolHRAdministration
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<IEmployee> employees = [];
            SeedData(employees);
            var jaesonEmployees = employees.Where(e => e.FirstName == "Jaeson").ToList();

            foreach (var emp in jaesonEmployees)
            {
                Console.WriteLine($"Employee: {emp.FirstName} {emp.LastName}, Salary: {emp.Salary}");
            }

            Console.WriteLine($"Employee Annual Salary: {employees.Sum(e => e.Salary)}");
            Console.ReadKey();
            
        }

        public static void SeedData(List<IEmployee> employees)
        {
            employees.Add(EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Jaeson", "Karter", 2000));
            employees.Add(EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Emily", "Smith", 2200));
            employees.Add(EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 3, "Michael", "Brown", 2500));
            employees.Add(EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 4, "Sophia", "Jones", 2300));

            employees.Add(EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 5, "David", "Clark", 3500));
            employees.Add(EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 6, "Olivia", "Martinez", 3700));
            employees.Add(EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 7, "Ethan", "Rodriguez", 3600));
            employees.Add(EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 8, "Ava", "Davis", 3800));

            employees.Add(EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 9, "William", "Taylor", 5000));
            employees.Add(EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 10, "Emma", "Anderson", 5200));
            employees.Add(EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 11, "James", "Thomas", 5100));
            employees.Add(EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 12, "Mia", "Harris", 5300));

            employees.Add(EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 13, "Benjamin", "White", 4000));
            employees.Add(EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 14, "Charlotte", "Moore", 4200));
            employees.Add(EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 15, "Alexander", "Wilson", 4100));
            employees.Add(EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 16, "Isabella", "Lee", 4300));
        }

        public static class EmployeeFactory
        {
            public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
            {
                IEmployee? employee = null;

                switch (employeeType)
                {
                    case EmployeeType.Teacher:
                        employee = FactoryPattern<IEmployee,Teacher>.GetInstance();
                        break;
                    case EmployeeType.HeadOfDepartment:
                        employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
                        break;
                    case EmployeeType.HeadMaster:
                        employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();
                        break;
                    case EmployeeType.DeputyHeadMaster:
                        employee = FactoryPattern<IEmployee, DeputyHeadOfDepartment>.GetInstance();
                        break;
                    default:
                        break;
                }      
                
                if(employee is not null)
                {
                    employee.FirstName = firstName;
                    employee.LastName = lastName;
                    employee.Salary = salary;
                    employee.Id = id;
                }
                else
                {
                    throw new NullReferenceException();
                }

                return employee ;

            }
        }
    }
}