using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Core.Entities
{
    public class InterviewFeedback
    {
        public int InterviewFeedbackId { get; set; }
        [Required]
        public int Rating { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Comment { get; set; }
        public int InterviewId { get; set; }
        public Interview Interview { get; set; }
    }
}
