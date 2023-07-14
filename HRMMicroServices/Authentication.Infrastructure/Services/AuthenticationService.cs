using System;
using Authentication.Core.Contracts.Repositories;
using Authentication.Core.Contracts.Services;
using Authentication.Core.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using IAuthenticationService = Authentication.Core.Contracts.Services.IAuthenticationService;

namespace Authentication.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        IAuthenticationRepository _authenticationRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationService(IAuthenticationRepository authenticationRepo, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _authenticationRepo = authenticationRepo;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };
            return await _userManager.CreateAsync(user, model.Password);
        }


        public async Task<SignInResult> LoginAsync(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            return result;
        }
    }
}

