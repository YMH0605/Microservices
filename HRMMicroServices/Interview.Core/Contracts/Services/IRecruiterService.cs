using Interview.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Core.Contracts.Services
{
    public interface IRecruiterService
    {
        Task<int> AddRecruiterAsync(RecruiterRequestModel model);
        Task<int> UpdateRecruiterAsync(RecruiterRequestModel model);
        Task<int> DeleteRecruiterAsync(int id);
        Task<IEnumerable<RecruiterResponseModel>> GetAllRecruiters();
        Task<RecruiterResponseModel> GetRecruiterByIdAsync(int id);
    }
}
