
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
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(AuthenticationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
