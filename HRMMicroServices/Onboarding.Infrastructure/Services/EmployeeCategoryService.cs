

using Onboarding.Core.Contracts.Repositories;
using Onboarding.Core.Contracts.Services;
using Onboarding.Core.Entities;
using Onboarding.Core.Exceptions;
using Onboarding.Core.Models;

namespace Onboarding.Infrastructure.Services
{
    public class EmployeeCategoryService : IEmployeeCategoryService
    {
        private readonly IEmployeeCategoryRepository repository;

        public EmployeeCategoryService(IEmployeeCategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddEmployeeCategoryAsync(EmployeeCategoryRequestModel model)
        {
            EmployeeCategory var = new();
            if (model != null)
            {
                var = new EmployeeCategory
                {
                    Description = model.Description,
                };
            }
            return await repository.InsertAsync(var);
        }

        public async Task<int> DeleteEmployeeCategoryAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeCategoryResponseModel>> GetAllEmployeeCategorys()
        {
            var var = await repository.GetAllAsync();
            return var.Select(x => new EmployeeCategoryResponseModel
            {
                LookupCode = x.LookupCode,
                Description = x.Description,
            });
        }

        public async Task<EmployeeCategoryResponseModel> GetEmployeeCategoryByIdAsync(int id)
        {
            var x = await repository.GetByIdAsync(id);
            if (x != null)
            {
                return new EmployeeCategoryResponseModel
                {
                    LookupCode = x.LookupCode,
                    Description = x.Description,
                };
            }
            throw new NotFoundException();
        }

        public async Task<int> UpdateEmployeeCategoryAsync(EmployeeCategoryRequestModel model)
        {
            var existing = await repository.GetByIdAsync(model.LookupCode);
            if (existing == null)
            {
                throw new Exception("EmployeeCategory does not exist");
            }
            if (model != null)
            {
                var var = new EmployeeCategory
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
