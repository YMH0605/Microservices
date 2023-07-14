using Interview.Core.Contracts.Services;
using Interview.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace InterviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {
        private readonly IInterviewerService service;
        public InterviewerController(IInterviewerService service)
        {
            this.service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(InterviewerRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.AddInterviewerAsync(model));
            }
            return BadRequest();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetInterviewerByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllInterviewers());
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteInterviewerAsync(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(InterviewerRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateInterviewerAsync(model));
            }
            return BadRequest();
        }
    }
}
