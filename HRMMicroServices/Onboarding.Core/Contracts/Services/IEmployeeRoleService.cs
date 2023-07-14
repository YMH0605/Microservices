using Onboarding.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Core.Contracts.Services
{
    public interface IEmployeeRoleService
    {
        Task<int> AddEmployeeRoleAsync(EmployeeRoleRequestModel model);
        Task<int> UpdateEmployeeRoleAsync(EmployeeRoleRequestModel model);
        Task<int> DeleteEmployeeRoleAsync(int id);
        Task<IEnumerable<EmployeeRoleResponseModel>> GetAllEmployeeRoles();
        Task<EmployeeRoleResponseModel> GetEmployeeRoleByIdAsync(int id);
    }
}
