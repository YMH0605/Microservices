using Onboarding.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Core.Contracts.Services
{
    public interface IEmployeeCategoryService
    {
        Task<int> AddEmployeeCategoryAsync(EmployeeCategoryRequestModel model);
        Task<int> UpdateEmployeeCategoryAsync(EmployeeCategoryRequestModel model);
        Task<int> DeleteEmployeeCategoryAsync(int id);
        Task<IEnumerable<EmployeeCategoryResponseModel>> GetAllEmployeeCategorys();
        Task<EmployeeCategoryResponseModel> GetEmployeeCategoryByIdAsync(int id);
    }
}
