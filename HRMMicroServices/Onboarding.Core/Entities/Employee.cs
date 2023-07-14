using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Core.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string? Middlename { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(9)")]
        public string SSN { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EndDate { get; set; }
        [ForeignKey(nameof(EmployeeCategory))]
        public int EmployeeCategoryCode { get; set; }
        [ForeignKey(nameof(EmployeeStatus))]
        public int EmployeeStatusCode { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Address { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string? Email { get; set; }
        public int EmployeeRoleId { get; set; }
        public EmployeeRole? EmployeeRole { get; set; }
        public EmployeeCategory? EmployeeCategory { get; set; }
        public EmployeeStatus? EmployeeStatus { get; set; }


    }
}
