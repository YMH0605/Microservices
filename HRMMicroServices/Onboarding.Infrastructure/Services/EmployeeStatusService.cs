

using Onboarding.Core.Contracts.Repositories;
using Onboarding.Core.Contracts.Services;
using Onboarding.Core.Entities;
using Onboarding.Core.Exceptions;
using Onboarding.Core.Models;

namespace Onboarding.Infrastructure.Services
{
    public class EmployeeStatusService : IEmployeeStatusService
    {
        private readonly IEmployeeStatusRepository repository;

        public EmployeeStatusService(IEmployeeStatusRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddEmployeeStatusAsync(EmployeeStatusRequestModel model)
        {
            EmployeeStatus var = new();
            if (model != null)
            {
                var = new EmployeeStatus
                {
                    Description = model.Description,
                    ABBR = model.ABBR,
                };
            }
            return await repository.InsertAsync(var);
        }

        public async Task<int> DeleteEmployeeStatusAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeStatusResponseModel>> GetAllEmployeeStatuss()
        {
            var var = await repository.GetAllAsync();
            return var.Select(x => new EmployeeStatusResponseModel
            {
                LookupCode = x.LookupCode,
                Description = x.Description,
                ABBR = x.ABBR,
            });
        }

        public async Task<EmployeeStatusResponseModel> GetEmployeeStatusByIdAsync(int id)
        {
            var x = await repository.GetByIdAsync(id);
            if (x != null)
            {
                return new EmployeeStatusResponseModel
                {
                    LookupCode = x.LookupCode,
                    Description = x.Description,
                    ABBR = x.ABBR,
                };
            }
            throw new NotFoundException();
        }

        public async Task<int> UpdateEmployeeStatusAsync(EmployeeStatusRequestModel model)
        {
            var existing = await repository.GetByIdAsync(model.LookupCode);
            if (existing == null)
            {
                throw new Exception("EmployeeStatus does not exist");
            }
            if (model != null)
            {
                var var = new EmployeeStatus
                {
                    LookupCode = model.LookupCode,
                    Description = model.Description,
                    ABBR = model.ABBR,
                };
                return await repository.UpdateAsync(var);
            }
            return -1;
        }
    }
}
