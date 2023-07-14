using Onboarding.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Core.Contracts.Services
{
    public interface IEmployeeStatusService
    {
        Task<int> AddEmployeeStatusAsync(EmployeeStatusRequestModel model);
        Task<int> UpdateEmployeeStatusAsync(EmployeeStatusRequestModel model);
        Task<int> DeleteEmployeeStatusAsync(int id);
        Task<IEnumerable<EmployeeStatusResponseModel>> GetAllEmployeeStatuss();
        Task<EmployeeStatusResponseModel> GetEmployeeStatusByIdAsync(int id);
    }
}
