using Onboarding.Core.Contracts.Services;
using Onboarding.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace OnboardingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCategoryController : ControllerBase
    {
        private readonly IEmployeeCategoryService service;
        public EmployeeCategoryController(IEmployeeCategoryService service)
        {
            this.service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(EmployeeCategoryRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.AddEmployeeCategoryAsync(model));
            }
            return BadRequest();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetEmployeeCategoryByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllEmployeeCategorys());
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteEmployeeCategoryAsync(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(EmployeeCategoryRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateEmployeeCategoryAsync(model));
            }
            return BadRequest();
        }
    }
}
