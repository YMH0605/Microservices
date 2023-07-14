using Interview.Core.Contracts.Services;
using Interview.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace InterviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewFeedbackController : ControllerBase
    {
        private readonly IInterviewFeedbackService service;
        public InterviewFeedbackController(IInterviewFeedbackService service)
        {
            this.service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(InterviewFeedbackRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.AddInterviewFeedbackAsync(model));
            }
            return BadRequest();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetInterviewFeedbackByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllInterviewFeedbacks());
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteInterviewFeedbackAsync(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(InterviewFeedbackRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateInterviewFeedbackAsync(model));
            }
            return BadRequest();
        }
    }
}
