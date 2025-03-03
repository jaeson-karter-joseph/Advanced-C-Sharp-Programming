using HRAdminstrationAPI.FactoryPattern;
using SchoolHRAdministration.DelegateFunction;
using SchoolHRAdministration.Events;
using SchoolHRAdministration.Events.Logger;
using SchoolHRAdministration.FactoryPattern;
using static SchoolHRAdministration.DelegateFunction.EnterpriseLoggingDemo;
using static SchoolHRAdministration.Events.BasicPubSub;
using static SchoolHRAdministration.Generics.Generics;

namespace SchoolHRAdministration
{
    internal partial class Program
    {
        delegate void LogDel(string text);

        private static void Main(string[] args)
        {
            //List<IEmployee> employees = FactoryPattern();
            //DelegateFunctions(employees);
            //Events(employees);

            Generics();

            Console.ReadKey();

        }

        private static void Generics()
        {
            var loggerService = new LoggerService<FileLogger>(new FileLogger());
            loggerService.WriteLog("Logging to file...");

            var consoleLoggerService = new LoggerService<ConsoleLogger>(new ConsoleLogger());
            consoleLoggerService.WriteLog("Logging to console...");
        }

        private static void Events(List<IEmployee> employees)
        {
            Publisher publisher = new();
            Subcriber subcriber = new();

            subcriber.Subcribe(publisher);
            publisher.TriggerEvent(employees);

            OrderProcessor orderProcessor = new();
            EmailService emailService = new();
            emailService.Subcribe(orderProcessor);
            orderProcessor.ProcessOrder(new OrderEvents("1", 1234));

            AtmMachine machine = new();
            BankLogger bankLogger = new();
            SmsNotification smsNotification = new();

            bankLogger.Subcribe(machine);
            smsNotification.Subcribe(machine);

            machine.WithdrawMoney("123-456-789", 250.00);
        }

        private static List<IEmployee> FactoryPattern()
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
            return employees;
        }

        private static void DelegateFunctions(List<IEmployee> employees)
        {
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


            ThreadSafeAysncCallback.RunWork().GetAwaiter().GetResult();
            #endregion
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