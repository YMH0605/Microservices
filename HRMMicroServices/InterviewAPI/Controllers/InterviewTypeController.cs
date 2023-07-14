using Interview.Core.Contracts.Services;
using Interview.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace InterviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewTypeController : ControllerBase
    {
        private readonly IInterviewTypeService service;
        public InterviewTypeController(IInterviewTypeService service)
        {
            this.service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(InterviewTypeRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.AddInterviewTypeAsync(model));
            }
            return BadRequest();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetInterviewTypeByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllInterviewTypes());
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteInterviewTypeAsync(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(InterviewTypeRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateInterviewTypeAsync(model));
            }
            return BadRequest();
        }
    }
}
