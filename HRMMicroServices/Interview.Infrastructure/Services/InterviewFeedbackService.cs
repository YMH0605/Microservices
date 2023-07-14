

using Interview.Core.Contracts.Repositories;
using Interview.Core.Contracts.Services;
using Interview.Core.Entities;
using Interview.Core.Exceptions;
using Interview.Core.Models;

namespace Interview.Infrastructure.Services
{
    public class InterviewFeedbackService : IInterviewFeedbackService
    {
        private readonly IInterviewFeedbackRepository repository;

        public InterviewFeedbackService(IInterviewFeedbackRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddInterviewFeedbackAsync(InterviewFeedbackRequestModel model)
        {
            InterviewFeedback var = new();
            if (model != null)
            {
                var = new InterviewFeedback
                {
                    Rating = model.Rating,
                    Comment = model.Comment,

                };
            }
            return await repository.InsertAsync(var);
        }

        public async Task<int> DeleteInterviewFeedbackAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewFeedbackResponseModel>> GetAllInterviewFeedbacks()
        {
            var var = await repository.GetAllAsync();
            return var.Select(x => new InterviewFeedbackResponseModel
            {
                InterviewFeedbackId=x.InterviewFeedbackId,
                Rating=x.Rating,
                Comment=x.Comment,
            });
        }

        public async Task<InterviewFeedbackResponseModel> GetInterviewFeedbackByIdAsync(int id)
        {
            var x = await repository.GetByIdAsync(id);
            if (x != null)
            {
                return new InterviewFeedbackResponseModel
                {
                    InterviewFeedbackId = x.InterviewFeedbackId,
                    Rating = x.Rating,
                    Comment = x.Comment,
                };
            }
            throw new NotFoundException();
        }

        public async Task<int> UpdateInterviewFeedbackAsync(InterviewFeedbackRequestModel model)
        {
            var existing = await repository.GetByIdAsync(model.InterviewFeedbackId);
            if (existing == null)
            {
                throw new Exception("InterviewFeedback does not exist");
            }
            if (model != null)
            {
                var var = new InterviewFeedback
                {
                    InterviewFeedbackId = model.InterviewFeedbackId,
                    Rating = model.Rating,
                    Comment = model.Comment,
                };
                return await repository.UpdateAsync(var);
            }
            return -1;
        }
    }
}
