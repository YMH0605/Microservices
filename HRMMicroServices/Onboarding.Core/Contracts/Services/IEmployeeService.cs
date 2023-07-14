using Onboarding.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Core.Contracts.Services
{
    public interface IEmployeeService
    {
        Task<int> AddEmployeeAsync(EmployeeRequestModel model);
        Task<int> UpdateEmployeeAsync(EmployeeRequestModel model);
        Task<int> DeleteEmployeeAsync(int id);
        Task<IEnumerable<EmployeeResponseModel>> GetAllEmployees();
        Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id);
    }
}
