using Interview.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Core.Contracts.Services
{
    public interface IInterviewerService
    {
        Task<int> AddInterviewerAsync(InterviewerRequestModel model);
        Task<int> UpdateInterviewerAsync(InterviewerRequestModel model);
        Task<int> DeleteInterviewerAsync(int id);
        Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewers();
        Task<InterviewerResponseModel> GetInterviewerByIdAsync(int id);
    }
}
