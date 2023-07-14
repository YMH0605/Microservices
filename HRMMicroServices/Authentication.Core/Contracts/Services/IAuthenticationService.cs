using System;
using Authentication.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.Contracts.Services
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> SignUpAsync(SignUpModel model);
        Task<SignInResult> LoginAsync(LoginModel model);
    }
}

