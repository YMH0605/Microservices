using Onboarding.Core.Contracts.Services;
using Onboarding.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace OnboardingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRoleController : ControllerBase
    {
        private readonly IEmployeeRoleService service;
        public EmployeeRoleController(IEmployeeRoleService service)
        {
            this.service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(EmployeeRoleRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.AddEmployeeRoleAsync(model));
            }
            return BadRequest();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetEmployeeRoleByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllEmployeeRoles());
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteEmployeeRoleAsync(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(EmployeeRoleRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateEmployeeRoleAsync(model));
            }
            return BadRequest();
        }
    }
}
