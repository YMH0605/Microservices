using Recruiting.Core.Contracts.Repositories;
using Recruiting.Core.Contracts.Services;
using Recruiting.Core.Entities;
using Recruiting.Core.Exceptions;
using Recruiting.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infrastructure.Services
{
    public class SubmissionStatusService : ISubmissionStatusService
    {
        private readonly ISubmissionStatusRepository repository;

        public SubmissionStatusService(ISubmissionStatusRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddSubmissionStatusAsync(SubmissionStatusRequestModel model)
        {
            SubmissionStatus submissionStatus = new();
            if (model != null)
            {
                submissionStatus = new SubmissionStatus
                {
                    Description = model.Description,
                };
            }
            return await repository.InsertAsync(submissionStatus);
        }

        public async Task<int> DeleteSubmissionStatusAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionStatusResponseModel>> GetAllSubmissionStatuss()
        {
            var ss = await repository.GetAllAsync();
            return ss.Select(x => new SubmissionStatusResponseModel
            {
                LookupCode = x.LookupCode,
                Description = x.Description,
            });
        }

        public async Task<SubmissionStatusResponseModel> GetSubmissionStatusByIdAsync(int id)
        {
            var ss = await repository.GetByIdAsync(id);
            if (ss != null)
            {
                return new SubmissionStatusResponseModel
                {
                    LookupCode = ss.LookupCode,
                    Description = ss.Description,
                };
            }
            throw new NotFoundException();
        }

        public async Task<int> UpdateSubmissionStatusAsync(SubmissionStatusRequestModel model)
        {
            var existingSS = await repository.GetByIdAsync(model.LookupCode);
            if (existingSS == null)
            {
                throw new Exception("Submission does not exist");
            }
            if (model != null)
            {
                SubmissionStatus ss = new SubmissionStatus
                {
                    LookupCode = model.LookupCode,
                    Description = model.Description,
                };
                return await repository.UpdateAsync(ss);
            }
            return -1;
        }
    }
}
