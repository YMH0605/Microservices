
using Authentication.Core.Contracts.Repositories;
using Authentication.Core.Entities;
using Authentication.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(AuthenticationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
