using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Core.Entities
{
    public class JobRequirement
    {
        public int JobRequirementId { get; set; }
        public int NumberOfPositions { get; set; }
        [Column(TypeName = "nvarchar(512)")]
        public string? Title { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string? Description { get; set; }
        public int HiringManagerId { get; set; }
        public string? HiringManagerName { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActivate { get; set; }
        public DateTime ClosedOn { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? ClosedReason { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? JobCategory { get; set; }
        public string? EmployeeType { get; set; }
        public List<Submission>? Submissions { get; set; }
    }
}
