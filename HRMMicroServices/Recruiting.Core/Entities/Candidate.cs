using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Core.Entities
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        [Required]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        [Required]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public string ResumeURL { get; set; }
        public List<Submission>? Submissions { get; set; }
    }
}
