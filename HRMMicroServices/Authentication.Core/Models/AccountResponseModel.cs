using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Core.Models
{
    public class AccountResponseModel
    {
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public string? Email { get; set; }
        public string? RoleId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? HashPassword { get; set; }
        public string? Salt { get; set; }
    }
}
