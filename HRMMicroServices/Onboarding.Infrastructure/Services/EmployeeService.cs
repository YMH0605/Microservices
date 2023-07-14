

using Onboarding.Core.Contracts.Repositories;
using Onboarding.Core.Contracts.Services;
using Onboarding.Core.Entities;
using Onboarding.Core.Exceptions;
using Onboarding.Core.Models;

namespace Onboarding.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddEmployeeAsync(EmployeeRequestModel model)
        {
            Employee var = new();
            if (model != null)
            {
                var = new Employee
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Middlename = model.Middlename,
                    SSN = model.SSN,
                    HireDate = model.HireDate,
                    EndDate = model.EndDate,
                    EmployeeCategoryCode = model.EmployeeCategoryCode,
                    EmployeeStatusCode = model.EmployeeStatusCode,
                    Address = model.Address,
                    Email = model.Email,
                    EmployeeRoleId = model.EmployeeRoleId,
                };
            }
            return await repository.InsertAsync(var);
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetAllEmployees()
        {
            var var = await repository.GetAllAsync();
            return var.Select(x => new EmployeeResponseModel
            {
                EmployeeId = x.EmployeeId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Middlename = x.Middlename,
                SSN = x.SSN,
                HireDate = x.HireDate,
                EndDate = x.EndDate,
                EmployeeCategoryCode = x.EmployeeCategoryCode,
                EmployeeStatusCode = x.EmployeeStatusCode,
                Address = x.Address,
                Email = x.Email,
                EmployeeRoleId = x.EmployeeRoleId,
            });
        }

        public async Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id)
        {
            var x = await repository.GetByIdAsync(id);
            if (x != null)
            {
                return new EmployeeResponseModel
                {
                    EmployeeId = x.EmployeeId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Middlename = x.Middlename,
                    SSN = x.SSN,
                    HireDate = x.HireDate,
                    EndDate = x.EndDate,
                    EmployeeCategoryCode = x.EmployeeCategoryCode,
                    EmployeeStatusCode = x.EmployeeStatusCode,
                    Address = x.Address,
                    Email = x.Email,
                    EmployeeRoleId = x.EmployeeRoleId,
                };
            }
            throw new NotFoundException();
        }

        public async Task<int> UpdateEmployeeAsync(EmployeeRequestModel model)
        {
            var existing = await repository.GetByIdAsync(model.EmployeeId);
            if (existing == null)
            {
                throw new Exception("Employee does not exist");
            }
            if (model != null)
            {
                var var = new Employee
                {
                    EmployeeId = model.EmployeeId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Middlename = model.Middlename,
                    SSN = model.SSN,
                    HireDate = model.HireDate,
                    EndDate = model.EndDate,
                    EmployeeCategoryCode = model.EmployeeCategoryCode,
                    EmployeeStatusCode = model.EmployeeStatusCode,
                    Address = model.Address,
                    Email = model.Email,
                    EmployeeRoleId = model.EmployeeRoleId,
                };
                return await repository.UpdateAsync(var);
            }
            return -1;
        }
    }
}
