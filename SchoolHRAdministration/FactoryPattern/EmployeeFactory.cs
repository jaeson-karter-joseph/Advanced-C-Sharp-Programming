using HRAdminstrationAPI.FactoryPattern;
using SchoolHRAdministration.FactoryPattern;

namespace SchoolHRAdministration
{

    internal partial class Program
    {
        public static class EmployeeFactory
        {
            public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
            {
                IEmployee? employee = null;

                switch (employeeType)
                {
                    case EmployeeType.Teacher:
                        employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
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

                if (employee is not null)
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

                return employee;

            }
        }
    }
}