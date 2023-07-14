using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Core.Entities
{
    public class EmployeeRole
    {
        [Key]
        public int LookupCode { get; set; }
        public string? Name { get; set; }
        public string? ABBR { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
