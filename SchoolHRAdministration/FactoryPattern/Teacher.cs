using HRAdminstrationAPI.FactoryPattern;

namespace SchoolHRAdministration.FactoryPattern
{
    public class Teacher : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + base.Salary * 0.02m; }
    }
}