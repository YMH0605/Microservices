

using Interview.Core.Contracts.Repositories;
using Interview.Core.Contracts.Services;
using Interview.Core.Entities;
using Interview.Core.Exceptions;
using Interview.Core.Models;

namespace Interview.Infrastructure.Services
{
    public class RecruiterService : IRecruiterService
    {
        private readonly IRecruiterRepository repository;

        public RecruiterService(IRecruiterRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddRecruiterAsync(RecruiterRequestModel model)
        {
            Recruiter var = new();
            if (model != null)
            {
                var = new Recruiter
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,  
                    EmployeeId = model.EmployeeId,
                };
            }
            return await repository.InsertAsync(var);
        }

        public async Task<int> DeleteRecruiterAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RecruiterResponseModel>> GetAllRecruiters()
        {
            var var = await repository.GetAllAsync();
            return var.Select(x => new RecruiterResponseModel
            {
                RecruiterId = x.RecruiterId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                EmployeeId = x.EmployeeId,
            });
        }

        public async Task<RecruiterResponseModel> GetRecruiterByIdAsync(int id)
        {
            var x = await repository.GetByIdAsync(id);
            if (x != null)
            {
                return new RecruiterResponseModel
                {
                    RecruiterId = x.RecruiterId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    EmployeeId = x.EmployeeId,
                };
            }
            throw new NotFoundException();
        }

        public async Task<int> UpdateRecruiterAsync(RecruiterRequestModel model)
        {
            var existing = await repository.GetByIdAsync(model.RecruiterId);
            if (existing == null)
            {
                throw new Exception("Recruiter does not exist");
            }
            if (model != null)
            {
                var var = new Recruiter
                {
                    RecruiterId = model.RecruiterId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmployeeId = model.EmployeeId,
                };
                return await repository.UpdateAsync(var);
            }
            return -1;
        }
    }
}
