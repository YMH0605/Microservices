

using Onboarding.Core.Contracts.Repositories;
using Onboarding.Core.Contracts.Services;
using Onboarding.Core.Entities;
using Onboarding.Core.Exceptions;
using Onboarding.Core.Models;

namespace Onboarding.Infrastructure.Services
{
    public class EmployeeRoleService : IEmployeeRoleService
    {
        private readonly IEmployeeRoleRepository repository;

        public EmployeeRoleService(IEmployeeRoleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddEmployeeRoleAsync(EmployeeRoleRequestModel model)
        {
            EmployeeRole var = new();
            if (model != null)
            {
                var = new EmployeeRole
                {
                    Name = model.Name,
                    ABBR = model.ABBR,
                };
            }
            return await repository.InsertAsync(var);
        }

        public async Task<int> DeleteEmployeeRoleAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeRoleResponseModel>> GetAllEmployeeRoles()
        {
            var var = await repository.GetAllAsync();
            return var.Select(x => new EmployeeRoleResponseModel
            {
                LookupCode = x.LookupCode,
                Name = x.Name,
                ABBR = x.ABBR,
            });
        }

        public async Task<EmployeeRoleResponseModel> GetEmployeeRoleByIdAsync(int id)
        {
            var x = await repository.GetByIdAsync(id);
            if (x != null)
            {
                return new EmployeeRoleResponseModel
                {
                    LookupCode = x.LookupCode,
                    Name = x.Name,
                    ABBR = x.ABBR,
                };
            }
            throw new NotFoundException();
        }

        public async Task<int> UpdateEmployeeRoleAsync(EmployeeRoleRequestModel model)
        {
            var existing = await repository.GetByIdAsync(model.LookupCode);
            if (existing == null)
            {
                throw new Exception("EmployeeRole does not exist");
            }
            if (model != null)
            {
                var var = new EmployeeRole
                {
                    LookupCode = model.LookupCode,
                    Name = model.Name,
                    ABBR = model.ABBR,
                };
                return await repository.UpdateAsync(var);
            }
            return -1;
        }
    }
}
