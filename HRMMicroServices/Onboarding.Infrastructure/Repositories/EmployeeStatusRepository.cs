
using Onboarding.Core.Contracts.Repositories;
using Onboarding.Core.Entities;
using Onboarding.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Infrastructure.Repositories
{
    public class EmployeeStatusRepository : BaseRepository<EmployeeStatus>, IEmployeeStatusRepository
    {
        public EmployeeStatusRepository(OnboardingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
