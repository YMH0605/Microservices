using Interview.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Core.Contracts.Services
{
    public interface IInterviewService
    {
        Task<int> AddInterviewAsync(InterviewRequestModel model);
        Task<int> UpdateInterviewAsync(InterviewRequestModel model);
        Task<int> DeleteInterviewAsync(int id);
        Task<IEnumerable<InterviewResponseModel>> GetAllInterviews();
        Task<InterviewResponseModel> GetInterviewByIdAsync(int id);
    }
}
