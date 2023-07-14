using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Core.Models.External
{
    public class SubmissionRequestModel
    {
        public int SubmissionId { get; set; }
        public int JobRequirementId { get; set; }
        public int CandidateId { get; set; }
        public int SubmissionStatusCode { get; set; }
        public DateTime SubmittedOn { get; set; }
        public DateTime ConfirmedOn { get; set; }
        public DateTime RejectedOn { get; set; }
    }
}
