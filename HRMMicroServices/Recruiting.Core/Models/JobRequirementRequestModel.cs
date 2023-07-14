using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Core.Models
{
    public class JobRequirementRequestModel
    {
        public int JobRequirementId { get; set; }
        public int NumberOfPositions { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int HiringManagerId { get; set; }
        public string? HiringManagerName { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActivate { get; set; }
        public DateTime ClosedOn { get; set; }
        public string? ClosedReason { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? JobCategory { get; set; }
        public string? EmployeeType { get; set; }
    }
}
