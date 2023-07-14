

using Interview.Core.Contracts.Repositories;
using Interview.Core.Contracts.Services;
using Interview.Core.Entities;
using Interview.Core.Exceptions;
using Interview.Core.Models;

namespace Interview.Infrastructure.Services
{
    public class InterviewerService : IInterviewerService
    {
        private readonly IInterviewerRepository repository;

        public InterviewerService(IInterviewerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddInterviewerAsync(InterviewerRequestModel model)
        {
            Interviewer var = new();
            if (model != null)
            {
                var = new Interviewer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmployeeId = model.EmployeeId,
                };
            }
            return await repository.InsertAsync(var);
        }

        public async Task<int> DeleteInterviewerAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewers()
        {
            var var = await repository.GetAllAsync();
            return var.Select(x => new InterviewerResponseModel
            {
                InterviewerId = x.InterviewerId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                EmployeeId = x.EmployeeId,
            });
        }

        public async Task<InterviewerResponseModel> GetInterviewerByIdAsync(int id)
        {
            var x = await repository.GetByIdAsync(id);
            if (x != null)
            {
                return new InterviewerResponseModel
                {
                    InterviewerId = x.InterviewerId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    EmployeeId = x.EmployeeId,
                };
            }
            throw new NotFoundException();
        }

        public async Task<int> UpdateInterviewerAsync(InterviewerRequestModel model)
        {
            var existing = await repository.GetByIdAsync(model.InterviewerId);
            if (existing == null)
            {
                throw new Exception("Interviewer does not exist");
            }
            if (model != null)
            {
                var var = new Interviewer
                {
                    InterviewerId = model.InterviewerId,
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
