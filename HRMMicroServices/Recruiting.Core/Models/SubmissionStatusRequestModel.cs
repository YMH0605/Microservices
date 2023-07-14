using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Core.Models
{
    public class SubmissionStatusRequestModel
    {
        public int LookupCode { get; set; }
        public string? Description { get; set; }
    }
}
