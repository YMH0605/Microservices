

using Authentication.Core.Contracts.Repositories;
using Authentication.Core.Contracts.Services;
using Authentication.Core.Entities;
using Authentication.Core.Exceptions;
using Authentication.Core.Models;

namespace Authentication.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddAccountAsync(AccountRequestModel model)
        {
            Account var = new();
            if (model != null)
            {
                var = new Account
                {
                    EmployeeId = model.EmployeeId,
                    Email = model.Email,
                    RoleId = model.RoleId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    HashPassword = model.HashPassword,
                    Salt = model.Salt,
                };
            }
            return await _repository.InsertAsync(var);
        }

        public async Task<int> DeleteAccountAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AccountResponseModel>> GetAllAccounts()
        {
            var var = await _repository.GetAllAsync();
            return var.Select(x => new AccountResponseModel
            {
                UserId = x.UserId,
                EmployeeId = x.EmployeeId,
                Email = x.Email,
                RoleId = x.RoleId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                HashPassword = x.HashPassword,
                Salt = x.Salt,
            });
        }

        public async Task<AccountResponseModel> GetAccountByIdAsync(int id)
        {
            var var = await _repository.GetByIdAsync(id);
            if (var != null)
            {
                return new AccountResponseModel
                {
                    UserId = var.UserId,
                    EmployeeId = var.EmployeeId,
                    Email = var.Email,
                    RoleId = var.RoleId,
                    FirstName = var.FirstName,
                    LastName = var.LastName,
                    HashPassword = var.HashPassword,
                    Salt = var.Salt,
                };
            }
            throw new NotFoundException();
        }

        public async Task<int> UpdateAccountAsync(AccountRequestModel model)
        {
            var existing = await _repository.GetByIdAsync(model.UserId);
            if (existing == null)
            {
                throw new Exception("Account does not exist");
            }
            if (model != null)
            {
                Account var = new Account
                {
                    UserId = model.UserId,
                    EmployeeId = model.EmployeeId,
                    Email = model.Email,
                    RoleId = model.RoleId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    HashPassword = model.HashPassword,
                    Salt = model.Salt,
                };
                return await _repository.UpdateAsync(var);
            }
            return -1;
        }
    }
}
