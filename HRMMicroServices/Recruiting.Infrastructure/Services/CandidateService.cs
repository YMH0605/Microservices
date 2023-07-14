using Recruiting.Core.Contracts.Repositories;
using Recruiting.Core.Contracts.Services;
using Recruiting.Core.Entities;
using Recruiting.Core.Exceptions;
using Recruiting.Core.Models;

namespace Recruiting.Infrastructure.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository repository;

        public CandidateService(ICandidateRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddCandidateAsync(CandidateRequestModel model)
        {
            Candidate candidate = new();
            if (model != null)
            {
                candidate = new Candidate
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Email = model.Email,
                    ResumeURL = model.ResumeURL,
                };
            }
            return await repository.InsertAsync(candidate);
        }

        public async Task<int> DeleteCandidateAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CandidateResponseModel>> GetAllCandidates()
        {
            var candidates = await repository.GetAllAsync();
            return candidates.Select(x => new CandidateResponseModel
            {
                CandidateId = x.CandidateId,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                Email = x.Email,
                ResumeURL = x.ResumeURL,
            });
        }

        public async Task<CandidateResponseModel> GetCandidateByIdAsync(int id)
        {
            var candidate = await repository.GetByIdAsync(id);
            if (candidate != null)
            {
                return new CandidateResponseModel
                {
                    CandidateId = candidate.CandidateId,
                    FirstName = candidate.FirstName,
                    MiddleName = candidate.MiddleName,
                    LastName = candidate.LastName,
                    Email = candidate.Email,
                    ResumeURL = candidate.ResumeURL,
                };
            }
            throw new NotFoundException();
        }

        public async Task<int> UpdateCandidateAsync(CandidateRequestModel model)
        {
            var existingCandidate = await repository.GetByIdAsync(model.CandidateId);
            if (existingCandidate == null)
            {
                throw new Exception("Candidate does not exist");
            }
            if (model != null)
            {
                Candidate candidate = new Candidate
                {
                    CandidateId = model.CandidateId,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Email = model.Email,
                    ResumeURL = model.ResumeURL,
                };
                return await repository.UpdateAsync(candidate);
            }
            return -1;
        }
    }
}
