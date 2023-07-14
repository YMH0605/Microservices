using Recruiting.Core.Contracts.Repositories;
using Recruiting.Core.Entities;
using Recruiting.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infrastructure.Repositories
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(RecruitingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
