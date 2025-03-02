using HRAdminstrationAPI.FactoryPattern;
using SchoolHRAdministration.DelegateFunction;
using SchoolHRAdministration.FactoryPattern;
using static SchoolHRAdministration.DelegateFunction.EnterpriseLoggingDemo;

namespace SchoolHRAdministration
{
    internal partial class Program
    {
        delegate void LogDel(string text);

        private static void Main(string[] args)
        {
            #region FactoryPattern
            List<IEmployee> employees = [];
            SeedData(employees);
            var jaesonEmployees = employees.Where(e => e.FirstName == "Jaeson").ToList();

            foreach (var emp in jaesonEmployees)
            {
                Console.WriteLine($"Employee: {emp.FirstName} {emp.LastName}, Salary: {emp.Salary}");
            }

            Console.WriteLine($"Employee Annual Salary: {employees.Sum(e => e.Salary)}");
            #endregion

            #region DelegateFunction
            DelegateBasics.DelegateFunction();

            Console.WriteLine("Choose a logging method (1 = Console, 2 = File): ");
            string choice = Console.ReadLine() ?? "1";

            LogHandler logHandler = choice switch
            {
                "2" => FileLog, // File Logging
                "3" => (LogHandler)ConsoleLog + FileLog, // Multicast Delegate: Console & File Logging
                _ => ConsoleLog // Console Logging (Default)
            };

            Logger logger = new(logHandler);

            logger.Log("Application started.");
            logger.Log("User logged in.");
            logger.Log("Error occurred: NullReferenceException");

            Console.WriteLine("Logging completed.");

            PredicateExample predicateExample = new(employees);
            predicateExample.PrintEmployees();



            #endregion

            Console.ReadKey();

        }

        static void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now} : {text}");
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
    }
}