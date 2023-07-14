using Authentication.Core.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Core.Contracts.Services
{
    public interface IAccountService
    {
        Task<int> AddAccountAsync(AccountRequestModel model);
        Task<int> UpdateAccountAsync(AccountRequestModel model);
        Task<int> DeleteAccountAsync(int id);
        Task<IEnumerable<AccountResponseModel>> GetAllAccounts();
        Task<AccountResponseModel> GetAccountByIdAsync(int id);
    }
}
