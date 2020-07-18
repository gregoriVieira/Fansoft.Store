using Fansoft.Store.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fansoft.Store.Api.Controllers
{
    public class EnvController : ControllerBase
    {
        private readonly SecuritySettings _securitySettings;
        public EnvController(SecuritySettings securitySettings)
        {
            _securitySettings = securitySettings;
        }

        [HttpGet("api/v1/env")]
        public IActionResult Get()
        {
            return Ok(new { appSettings = _securitySettings });
        }

        [HttpGet("api/v1/version")]
        public IActionResult GetVersion()
        {
            return Ok(new { version = "1.1" });
        }

    }
}