using Interview.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Core.Contracts.Services
{
    public interface IInterviewTypeService
    {
        Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel model);
        Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel model);
        Task<int> DeleteInterviewTypeAsync(int id);
        Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypes();
        Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsync(int id);
    }
}
