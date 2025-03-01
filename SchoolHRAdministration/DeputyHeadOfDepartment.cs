using HRAdminstrationAPI;

namespace SchoolHRAdministration
{
    public class DeputyHeadOfDepartment : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); }
    }
}