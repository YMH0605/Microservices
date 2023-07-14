using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Core.Models
{
    public class InterviewTypeResponseModel
    {
        public int LookupCode { get; set; }
        public string? Description { get; set; }
    }
}
