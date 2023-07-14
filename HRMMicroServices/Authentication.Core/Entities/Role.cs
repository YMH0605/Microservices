using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Core.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        [Column(TypeName = "nvarchar(129)")]
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Description { get; set; }
        public List<UserRole>? UserRoles { get; set; }
    }
}
