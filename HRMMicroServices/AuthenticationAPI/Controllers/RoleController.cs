using Authentication.Core.Contracts.Services;
using Authentication.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService service;
        public RoleController(IRoleService service)
        {
            this.service = service;

        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(RoleRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.AddRoleAsync(model));
            }
            return BadRequest();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetRoleByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllRoles());
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteRoleAsync(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(RoleRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateRoleAsync(model));
            }
            return BadRequest();
        }
    }
}
