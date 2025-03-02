namespace HRAdminstrationAPI.FactoryPattern
{
    public abstract class EmployeeBase : IEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public virtual decimal Salary { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, FirstName: {FirstName}, LastName: {LastName}, Salary: {Salary}";
        }
    }
}
