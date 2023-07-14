using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Core.Entities
{
    public class Account
    {
        [Key]
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public string? Email { get; set; }
        public string? RoleId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? HashPassword { get; set; }
        public string? Salt { get; set; }
        public List<UserRole>? UserRoles { get; set; }
    }
}
