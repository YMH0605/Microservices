using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Core.Entities
{
    public class InterviewType
    {
        [Key]
        public int LookupCode { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string? Description { get; set; }
        public List<Interview>? Interviews { get; set; }
    }
}
