using Onboarding.Core.Contracts.Services;
using Onboarding.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace OnboardingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService service;
        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(EmployeeRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.AddEmployeeAsync(model));
            }
            return BadRequest();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetEmployeeByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllEmployees());
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteEmployeeAsync(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(EmployeeRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateEmployeeAsync(model));
            }
            return BadRequest();
        }
    }
}
