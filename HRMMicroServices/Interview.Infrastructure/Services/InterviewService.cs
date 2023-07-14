

using Interview.Core.Contracts.Repositories;
using Interview.Core.Contracts.Services;
using Interview.Core.Entities;
using Interview.Core.Exceptions;
using Interview.Core.Models;

namespace Interview.Infrastructure.Services
{
    public class InterviewService : IInterviewService
    {
        private readonly IInterviewRepository repository;

        public InterviewService(IInterviewRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddInterviewAsync(InterviewRequestModel model)
        {
            Core.Entities.Interview var = new();
            if (model != null)
            {
                var = new Core.Entities.Interview
                {
                    RecruiterId=model.RecruiterId,
                    SubmissionId=model.SubmissionId,
                    InterviewTypeCode=model.InterviewTypeCode,
                    InterviewRound=model.InterviewRound,   
                    ScheduledOn=model.ScheduledOn,
                    InterviewerId=model.InterviewerId,
                };
            }
            return await repository.InsertAsync(var);
        }

        public async Task<int> DeleteInterviewAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewResponseModel>> GetAllInterviews()
        {
            var var = await repository.GetAllAsync();
            return var.Select(x => new InterviewResponseModel
            {
                InterviewId = x.InterviewId,
                RecruiterId = x.RecruiterId,
                SubmissionId = x.SubmissionId,
                InterviewTypeCode = x.InterviewTypeCode,
                InterviewRound = x.InterviewRound,
                ScheduledOn = x.ScheduledOn,
                InterviewerId = x.InterviewerId,
            });
        }

        public async Task<InterviewResponseModel> GetInterviewByIdAsync(int id)
        {
            var x = await repository.GetByIdAsync(id);
            if (x != null)
            {
                return new InterviewResponseModel
                {
                    InterviewId = x.InterviewId,
                    RecruiterId = x.RecruiterId,
                    SubmissionId = x.SubmissionId,
                    InterviewTypeCode = x.InterviewTypeCode,
                    InterviewRound = x.InterviewRound,
                    ScheduledOn = x.ScheduledOn,
                    InterviewerId = x.InterviewerId,
                };
            }
            throw new NotFoundException();
        }

        public async Task<int> UpdateInterviewAsync(InterviewRequestModel model)
        {
            var existing = await repository.GetByIdAsync(model.InterviewId);
            if (existing == null)
            {
                throw new Exception("Interview does not exist");
            }
            if (model != null)
            {
                var var = new Core.Entities.Interview
                {
                    InterviewId = model.InterviewId,
                    RecruiterId = model.RecruiterId,
                    SubmissionId = model.SubmissionId,
                    InterviewTypeCode = model.InterviewTypeCode,
                    InterviewRound = model.InterviewRound,
                    ScheduledOn = model.ScheduledOn,
                    InterviewerId = model.InterviewerId,
                };
                return await repository.UpdateAsync(var);
            }
            return -1;
        }
    }
}
