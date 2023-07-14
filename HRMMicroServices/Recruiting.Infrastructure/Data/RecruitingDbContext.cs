using Microsoft.EntityFrameworkCore;
using Recruiting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infrastructure.Data
{
    public class RecruitingDbContext : DbContext
    {
        public RecruitingDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(builder =>
            {
                builder.ToTable("Candidate");
                builder.HasIndex(x => x.Email).IsUnique();
            });
            modelBuilder.Entity<Submission>(builder =>
            {
                builder.ToTable("Submission");
                builder.HasIndex(x => new { x.CandidateId, x.JobRequirementId }).IsUnique();
            });
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<JobRequirement> JobRequirements { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<SubmissionStatus> SubmissionStatuses { get; set; }
    }
}
