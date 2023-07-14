using Recruiting.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Core.Contracts.Services
{
    public interface IJobRequirementService
    {
        Task<int> AddJobRequirementAsync(JobRequirementRequestModel model);
        Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model);
        Task<int> DeleteJobRequirementAsync(int id);
        Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirements();
        Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id);
    }
}
