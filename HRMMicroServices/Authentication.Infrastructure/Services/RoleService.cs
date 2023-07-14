
using Authentication.Core.Contracts.Repositories;
using Authentication.Core.Contracts.Services;
using Authentication.Core.Entities;
using Authentication.Core.Exceptions;
using Authentication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddRoleAsync(RoleRequestModel model)
        {
            Role var = new();
            if (model != null)
            {
                var = new Role
                {
                    Name = model.Name,
                    Description = model.Description,
                };
            }
            return await _repository.InsertAsync(var);
        }

        public async Task<int> DeleteRoleAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RoleResponseModel>> GetAllRoles()
        {
            var var = await _repository.GetAllAsync();
            return var.Select(x => new RoleResponseModel
            {
                RoleId = x.RoleId,
                Name = x.Name,
                Description = x.Description,
            });
        }

        public async Task<RoleResponseModel> GetRoleByIdAsync(int id)
        {
            var var = await _repository.GetByIdAsync(id);
            if (var != null)
            {
                return new RoleResponseModel
                {
                    RoleId = var.RoleId,
                    Name = var.Name,
                    Description = var.Description,
                };
            }
            throw new NotFoundException();
        }

        public async Task<int> UpdateRoleAsync(RoleRequestModel model)
        {
            var existing = await _repository.GetByIdAsync(model.RoleId);
            if (existing == null)
            {
                throw new Exception("Role does not exist");
            }
            if (model != null)
            {
                Role var = new Role
                {
                    RoleId = model.RoleId,
                    Name = model.Name,
                    Description = model.Description,
                };
                return await _repository.UpdateAsync(var);
            }
            return -1;
        }
    }
}
