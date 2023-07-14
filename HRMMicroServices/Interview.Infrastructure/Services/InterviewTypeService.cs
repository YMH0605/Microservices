

using Interview.Core.Contracts.Repositories;
using Interview.Core.Contracts.Services;
using Interview.Core.Entities;
using Interview.Core.Exceptions;
using Interview.Core.Models;

namespace Interview.Infrastructure.Services
{
    public class InterviewTypeService : IInterviewTypeService
    {
        private readonly IInterviewTypeRepository repository;

        public InterviewTypeService(IInterviewTypeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            InterviewType var = new();
            if (model != null)
            {
                var = new InterviewType
                {
                    Description = model.Description,

                };
            }
            return await repository.InsertAsync(var);
        }

        public async Task<int> DeleteInterviewTypeAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypes()
        {
            var var = await repository.GetAllAsync();
            return var.Select(x => new InterviewTypeResponseModel
            {
                LookupCode = x.LookupCode,
                Description = x.Description,
            });
        }

        public async Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsync(int id)
        {
            var x = await repository.GetByIdAsync(id);
            if (x != null)
            {
                return new InterviewTypeResponseModel
                {
                    LookupCode = x.LookupCode,
                    Description = x.Description,
                };
            }
            throw new NotFoundException();
        }

        public async Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            var existing = await repository.GetByIdAsync(model.LookupCode);
            if (existing == null)
            {
                throw new Exception("InterviewType does not exist");
            }
            if (model != null)
            {
                var var = new InterviewType
                {
                    LookupCode = model.LookupCode,
                    Description = model.Description,
                };
                return await repository.UpdateAsync(var);
            }
            return -1;
        }
    }
}
