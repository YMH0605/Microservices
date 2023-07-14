
using Dapper;
using Interview.Core.Contracts.Repositories;
using Interview.Core.Entities;
using Interview.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Infrastructure.Repositories
{
    public class InterviewRepository : IBaseRepository<Core.Entities.Interview>, IInterviewRepository
    {
        protected readonly InterviewDbContext dbContext;

        public InterviewRepository(InterviewDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> DeleteAsync(int id)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Delete From Interviews Where InterviewId=@InterviewId", new { InterviewId = id });
            }
        }

        public async Task<IEnumerable<Core.Entities.Interview>> GetAllAsync()
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.QueryAsync<Core.Entities.Interview>("Select * From Interviews");
            }
        }

        public async Task<Core.Entities.Interview> GetByIdAsync(int id)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.QuerySingleOrDefaultAsync<Core.Entities.Interview>("Select * From Interviews Where InterviewId=@InterviewId", new { InterviewId = id });
            }
        }

        public async Task<int> InsertAsync(Core.Entities.Interview entity)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Insert Into Interviews Values(@RecruiterId, @SubmissionId, @InterviewTypeCode, @InterviewRound, @ScheduledOn, @InterviewerId)", entity);
            }
        }

        public async Task<int> UpdateAsync(Core.Entities.Interview entity)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Update Interviews set RecruiterId=@RecruiterId, SubmissionId=@SubmissionId, InterviewTypeCode=@InterviewTypeCode, InterviewRound=@InterviewRound, ScheduledOn=@ScheduledOn, InterviewerId=@InterviewerId, FeedbackId=@FeedbackId Where InterviewId=@InterviewId", entity);
            }
        }
    }
}
