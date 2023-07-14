using Interview.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Core.Contracts.Services
{
    public interface IInterviewFeedbackService
    {
        Task<int> AddInterviewFeedbackAsync(InterviewFeedbackRequestModel model);
        Task<int> UpdateInterviewFeedbackAsync(InterviewFeedbackRequestModel model);
        Task<int> DeleteInterviewFeedbackAsync(int id);
        Task<IEnumerable<InterviewFeedbackResponseModel>> GetAllInterviewFeedbacks();
        Task<InterviewFeedbackResponseModel> GetInterviewFeedbackByIdAsync(int id);
    }
}
