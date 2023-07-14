using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Core.Entities
{
    public class Submission
    {
        public int SubmissionId { get; set; }
        public int JobRequirementId { get; set; }
        public JobRequirement JobRequirement { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        [ForeignKey(nameof(SubmissionStatus))]
        public int SubmissionStatusCode { get; set; }
        public SubmissionStatus SubmissionStatus { get; set; }
        public DateTime SubmittedOn { get; set; }
        public DateTime ConfirmedOn { get; set; }
        public DateTime RejectedOn { get; set; }
    }
}
