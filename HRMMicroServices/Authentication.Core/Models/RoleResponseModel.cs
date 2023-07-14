using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Core.Models
{
    public class RoleResponseModel
    {
        public int RoleId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
