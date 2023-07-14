using Interview.Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Infrastructure.Data
{
    //public class InterviewDbContext : DbContext
    //{
    //    public InterviewDbContext(DbContextOptions options) : base(options)
    //    {
    //    }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);
    //    }

    //    public DbSet<Core.Entities.Interview> Interviews { get; set; }
    //    public DbSet<Interviewer> Interviewers { get; set; }
    //    public DbSet<InterviewFeedback> InterviewFeedbacks { get; set; }
    //    public DbSet<InterviewType> InterviewTypes { get; set; }
    //    public DbSet<Recruiter> Recruiters { get; set; }
    //}
    public class InterviewDbContext
    {
        private readonly string connectionString;
        public InterviewDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);

        }

    }
}
