using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuineaPigApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{v:ApiVersion}/[controller]")]
    [ApiController]
    public class Status : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API is running");
        }
    }
}
