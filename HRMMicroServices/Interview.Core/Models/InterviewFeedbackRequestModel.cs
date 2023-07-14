using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Core.Models
{
    public class InterviewFeedbackRequestModel
    {
        public int InterviewFeedbackId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public int InterviewId { get; set; }
    }
}
