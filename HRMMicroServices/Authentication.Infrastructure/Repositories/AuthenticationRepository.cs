using Authentication.Core.Contracts.Repositories;
using Authentication.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Repositories
{
    public class AuthenticationRepository:IAuthenticationRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            ApplicationUser user = new ApplicationUser() { 
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            UserName=model.Email
            
            };
            return await _userManager.CreateAsync(user,model.Password);
        }
        public async Task<SignInResult> LoginAsync(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            return result;
        }
    }
}
