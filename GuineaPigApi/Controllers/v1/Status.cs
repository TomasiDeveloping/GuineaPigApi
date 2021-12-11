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
            try
            {
                return Ok("API is running");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
