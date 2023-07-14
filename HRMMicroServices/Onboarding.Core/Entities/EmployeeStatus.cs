using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Core.Entities
{
    public class EmployeeStatus
    {
        [Key]
        public int LookupCode { get; set; }
        [Column(TypeName = "nvarchar(512)")]
        public string? Description { get; set; }
        [Column(TypeName = "nvarchar(16)")]
        public string? ABBR { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
