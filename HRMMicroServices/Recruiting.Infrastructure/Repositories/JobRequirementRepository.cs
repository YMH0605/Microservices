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
    public class JobRequirementRepository : BaseRepository<JobRequirement>, IJobRequirementRepository
    {
        public JobRequirementRepository(RecruitingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
