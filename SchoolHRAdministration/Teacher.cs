using HRAdminstrationAPI;

namespace SchoolHRAdministration
{
    public class Teacher : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); }
    }
}