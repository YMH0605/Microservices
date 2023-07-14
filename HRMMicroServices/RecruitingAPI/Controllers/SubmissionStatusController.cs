using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruiting.Core.Contracts.Services;
using Recruiting.Core.Models;

namespace RecruitingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionStatusController : ControllerBase
    {
        private readonly ISubmissionStatusService service;
        public SubmissionStatusController(ISubmissionStatusService service)
        {
            this.service = service;

        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(SubmissionStatusRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.AddSubmissionStatusAsync(model));
            }
            return BadRequest();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetSubmissionStatusByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllSubmissionStatuss());
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteSubmissionStatusAsync(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(SubmissionStatusRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateSubmissionStatusAsync(model));
            }
            return BadRequest();
        }
    }
}
