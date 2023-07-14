using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Core.Entities
{
    public class Interviewer
    {
        public int InterviewerId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string LastName { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public List<Interview>? Interviews { get; set; }
    }
}
