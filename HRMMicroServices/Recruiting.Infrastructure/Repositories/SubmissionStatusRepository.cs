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
    public class SubmissionStatusRepository : BaseRepository<SubmissionStatus>, ISubmissionStatusRepository
    {
        public SubmissionStatusRepository(RecruitingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
