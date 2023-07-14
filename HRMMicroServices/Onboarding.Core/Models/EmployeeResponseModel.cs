using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Core.Models
{
    public class EmployeeResponseModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Middlename { get; set; }
        public string SSN { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int EmployeeCategoryCode { get; set; }
        public int EmployeeStatusCode { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public int EmployeeRoleId { get; set; }


    }
}
