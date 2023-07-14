using Interview.Core.Contracts.Services;
using Interview.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace InterviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterService service;
        public RecruiterController(IRecruiterService service)
        {
            this.service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(RecruiterRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.AddRecruiterAsync(model));
            }
            return BadRequest();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetRecruiterByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllRecruiters());
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteRecruiterAsync(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(RecruiterRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateRecruiterAsync(model));
            }
            return BadRequest();
        }
    }
}
