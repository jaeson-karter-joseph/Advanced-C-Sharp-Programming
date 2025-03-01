using HRAdminstrationAPI.FactoryPattern;

namespace SchoolHRAdministration.FactoryPattern
{
    public class HeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + base.Salary * 0.05m; }
    }
}