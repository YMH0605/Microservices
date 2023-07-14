using Onboarding.Core.Contracts.Services;
using Onboarding.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace OnboardingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeStatusController : ControllerBase
    {
        private readonly IEmployeeStatusService service;
        public EmployeeStatusController(IEmployeeStatusService service)
        {
            this.service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(EmployeeStatusRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.AddEmployeeStatusAsync(model));
            }
            return BadRequest();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetEmployeeStatusByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllEmployeeStatuss());
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteEmployeeStatusAsync(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(EmployeeStatusRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateEmployeeStatusAsync(model));
            }
            return BadRequest();
        }
    }
}
