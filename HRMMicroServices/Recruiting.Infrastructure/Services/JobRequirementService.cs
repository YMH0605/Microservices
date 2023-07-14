using Recruiting.Core.Contracts.Repositories;
using Recruiting.Core.Contracts.Services;
using Recruiting.Core.Entities;
using Recruiting.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infrastructure.Services
{
    public class JobRequirementService : IJobRequirementService
    {
        private readonly IJobRequirementRepository repository;

        public JobRequirementService(IJobRequirementRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddJobRequirementAsync(JobRequirementRequestModel model)
        {
            JobRequirement jr = new();
            if (model != null)
            {
                jr = new JobRequirement
                {
                    NumberOfPositions = model.NumberOfPositions,
                    Title = model.Title,
                    Description = model.Description,
                    HiringManagerId = model.HiringManagerId,
                    HiringManagerName = model.HiringManagerName,
                    StartDate = model.StartDate,
                    IsActivate = model.IsActivate,
                    ClosedOn = model.ClosedOn,
                    ClosedReason = model.ClosedReason,
                    CreatedOn = model.CreatedOn,
                    JobCategory = model.JobCategory,
                    EmployeeType = model.EmployeeType,
                };
            }
            return await repository.InsertAsync(jr);
        }

        public async Task<int> DeleteJobRequirementAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirements()
        {
            var jrs = await repository.GetAllAsync();
            return jrs.Select(x => new JobRequirementResponseModel
            {
                JobRequirementId = x.JobRequirementId,
                NumberOfPositions = x.NumberOfPositions,
                Title = x.Title,
                Description = x.Description,
                HiringManagerId = x.HiringManagerId,
                HiringManagerName = x.HiringManagerName,
                StartDate = x.StartDate,
                IsActivate = x.IsActivate,
                ClosedOn = x.ClosedOn,
                ClosedReason = x.ClosedReason,
                CreatedOn = x.CreatedOn,
                JobCategory = x.JobCategory,
                EmployeeType = x.EmployeeType,
            });
        }

        public async Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id)
        {
            var jr = await repository.GetByIdAsync(id);
            return new JobRequirementResponseModel
            {
                JobRequirementId = jr.JobRequirementId,
                NumberOfPositions = jr.NumberOfPositions,
                Title = jr.Title,
                Description = jr.Description,
                HiringManagerId = jr.HiringManagerId,
                HiringManagerName = jr.HiringManagerName,
                StartDate = jr.StartDate,
                IsActivate = jr.IsActivate,
                ClosedOn = jr.ClosedOn,
                ClosedReason = jr.ClosedReason,
                CreatedOn = jr.CreatedOn,
                JobCategory = jr.JobCategory,
                EmployeeType = jr.EmployeeType,
            };
        }

        public async Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model)
        {
            var existingJr = await repository.GetByIdAsync(model.JobRequirementId);
            if (existingJr == null)
            {
                throw new Exception("JobRequirement does not exist");
            }
            if (model != null)
            {
                JobRequirement jr = new JobRequirement
                {
                    JobRequirementId = model.JobRequirementId,
                    NumberOfPositions = model.NumberOfPositions,
                    Title = model.Title,
                    Description = model.Description,
                    HiringManagerId = model.HiringManagerId,
                    HiringManagerName = model.HiringManagerName,
                    StartDate = model.StartDate,
                    IsActivate = model.IsActivate,
                    ClosedOn = model.ClosedOn,
                    ClosedReason = model.ClosedReason,
                    CreatedOn = model.CreatedOn,
                    JobCategory = model.JobCategory,
                    EmployeeType = model.EmployeeType,
                };
                return await repository.UpdateAsync(jr);
            }
            return -1;
        }
    }
}
