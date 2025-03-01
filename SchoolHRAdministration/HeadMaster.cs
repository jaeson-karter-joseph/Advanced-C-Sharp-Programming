using HRAdminstrationAPI;

namespace SchoolHRAdministration
{
    public class HeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); }
    }
}