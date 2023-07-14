using Recruiting.Core.Contracts.Repositories;
using Recruiting.Core.Contracts.Services;
using Recruiting.Core.Entities;
using Recruiting.Core.Exceptions;
using Recruiting.Core.Models;
using Recruiting.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infrastructure.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepository repository;

        public SubmissionService(ISubmissionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddSubmissionAsync(SubmissionRequestModel model)
        {
            Submission submission = new();
            if (model != null)
            {
                submission = new Submission
                {
                    JobRequirementId = model.JobRequirementId,
                    CandidateId = model.CandidateId,
                    SubmissionStatusCode = model.SubmissionStatusCode,
                    SubmittedOn = model.SubmittedOn,
                    ConfirmedOn = model.ConfirmedOn,
                    RejectedOn = model.RejectedOn,
                };
            }
            return await repository.InsertAsync(submission);
        }

        public async Task<int> DeleteSubmissionAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissions()
        {
            var submissions = await repository.GetAllAsync();
            return submissions.Select(x => new SubmissionResponseModel
            {
                SubmissionId = x.SubmissionId,
                JobRequirementId = x.JobRequirementId,
                CandidateId = x.CandidateId,
                SubmissionStatusCode = x.SubmissionStatusCode,
                SubmittedOn = x.SubmittedOn,
                ConfirmedOn = x.ConfirmedOn,
                RejectedOn = x.RejectedOn,
            });
        }

        public async Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id)
        {
            var submission = await repository.GetByIdAsync(id);
            if (submission != null)
            {
                return new SubmissionResponseModel
                {
                    SubmissionId = submission.SubmissionId,
                    JobRequirementId = submission.JobRequirementId,
                    CandidateId = submission.CandidateId,
                    SubmissionStatusCode = submission.SubmissionStatusCode,
                    SubmittedOn = submission.SubmittedOn,
                    ConfirmedOn = submission.ConfirmedOn,
                    RejectedOn = submission.RejectedOn,
                };
            }
            throw new NotFoundException();
        }

        public async Task<int> UpdateSubmissionAsync(SubmissionRequestModel model)
        {
            var existingSubmission = await repository.GetByIdAsync(model.SubmissionId);
            if (existingSubmission == null)
            {
                throw new Exception("Submission does not exist");
            }
            if (model != null)
            {
                Submission submission = new Submission
                {
                    SubmissionId = model.SubmissionId,
                    JobRequirementId = model.JobRequirementId,
                    CandidateId = model.CandidateId,
                    SubmissionStatusCode = model.SubmissionStatusCode,
                    SubmittedOn = model.SubmittedOn,
                    ConfirmedOn = model.ConfirmedOn,
                    RejectedOn = model.RejectedOn,
                };
                return await repository.UpdateAsync(submission);
            }
            return -1;
        }
    }
}
