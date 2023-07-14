using Authentication.Core.Contracts.Repositories;
using Authentication.Core.Contracts.Services;
using Authentication.Core.Models;
using JWTAuthenticationManager;
using JWTAuthenticationManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService service;
        private readonly JwtTokenHandler jwtTokenHandler;
        private readonly IAuthenticationRepository authenticationRepository;

        public AccountController(IAccountService service, JwtTokenHandler jwtTokenHandler, IAuthenticationRepository authenticationRepository)
        {
            this.service = service;
            this.jwtTokenHandler = jwtTokenHandler;
            this.authenticationRepository = authenticationRepository;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(AccountRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.AddAccountAsync(model));
            }
            return BadRequest();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetAccountByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllAccounts());
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteAccountAsync(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(AccountRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateAccountAsync(model));
            }
            return BadRequest();
        }
        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await authenticationRepository.LoginAsync(model);
            if (result.Succeeded)
            {
                AuthenticationRequest request = new AuthenticationRequest() {
                 Username = model.Username,
                 Password = model.Password
                };
                var response = jwtTokenHandler.GenerateToken(request, "admin");
                if (response == null) return Unauthorized();
                return Ok(response);
            }
            return Unauthorized();
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            var result = await authenticationRepository.SignUpAsync(model);
            if (result.Succeeded) return Ok("Your account has been created");

            return BadRequest();
        }

    }
}
