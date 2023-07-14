using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruiting.Core.Contracts.Services;
using Recruiting.Core.Models;
using Recruiting.Infrastructure.Services;

namespace RecruitingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService service;
        private readonly ILogger<CandidateController> logger;
        public CandidateController(ICandidateService service, ILogger<CandidateController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.logger.LogInformation("Logger Activated!");
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CandidateRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.AddCandidateAsync(model));
            }
            return BadRequest();
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetCandidateByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllCandidates());
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteCandidateAsync(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(CandidateRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateCandidateAsync(model));
            }
            return BadRequest();
        }
    }
}
