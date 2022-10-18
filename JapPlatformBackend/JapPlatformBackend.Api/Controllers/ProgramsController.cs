using JapPlatformBackend.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JapPlatformBackend.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly IProgramService programService;

        public ProgramsController(IProgramService programService)
        {
            this.programService = programService;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            return Ok(await programService.List());
        }
    }
}
