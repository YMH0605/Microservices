
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
    public class InterviewFeedbackRepository : IBaseRepository<InterviewFeedback>, IInterviewFeedbackRepository
    {
        protected readonly InterviewDbContext dbContext;

        public InterviewFeedbackRepository(InterviewDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> DeleteAsync(int id)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Delete From InterviewFeedbacks Where InterviewFeedbackId=@InterviewFeedbackId", new { InterviewFeedbackId = id });
            }
        }

        public async Task<IEnumerable<InterviewFeedback>> GetAllAsync()
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.QueryAsync<InterviewFeedback>("Select * From InterviewFeedbacks");
            }
        }

        public async Task<InterviewFeedback> GetByIdAsync(int id)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.QuerySingleOrDefaultAsync<InterviewFeedback>("Select * From InterviewFeedbacks Where InterviewFeedbackId=@InterviewFeedbackId", new { InterviewFeedbackId = id });
            }
        }

        public async Task<int> InsertAsync(InterviewFeedback entity)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Insert Into InterviewFeedbacks Values(@Rating, @Comment, @InterviewId)", entity);
            }
        }

        public async Task<int> UpdateAsync(InterviewFeedback entity)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Update InterviewFeedbacks set Rating=@Rating, Comment=@Comment, InterviewId=@InterviewId Where InterviewFeedbackId=@InterviewFeedbackId", entity);
            }
        }
    }
}
