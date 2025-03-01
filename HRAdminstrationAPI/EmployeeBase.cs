using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAdminstrationAPI
{
    public abstract class EmployeeBase : IEmployee
    {
        public int Id { get ; set ; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public virtual decimal Salary { get ; set ; }
    }
}
