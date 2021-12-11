using GuineaPigApi.DTOs;
using GuineaPigApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GuineaPigApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{v:ApiVersion}/[controller]")]
    [ApiController]
    public class HealthChecksController : ControllerBase
    {
        private readonly IHealthCheckService _service;
        public HealthChecksController(IHealthCheckService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetHealthChecks()
        {
            var healthChecks = await _service.GetHealthChecksAsync();
            if (healthChecks.Count() < 0) return NoContent();
            return Ok(healthChecks);
        }

        [HttpGet("{healthCheckId:int}")]
        public async Task<IActionResult> GetHealthChecks(int healthCheckId)
        {
            var healthCheck = await _service.GetHealthCheckByIdAsync(healthCheckId);
            return Ok(healthCheck);
        }

        [HttpGet("guineaPig/{guineaPigId:int}")]
        public async Task<IActionResult> GetHealthChecksByGuineaPigId(int guineaPigId)
        {
            var healthChecks = await _service.GetHealthChecksByGuineaPigIdAsync(guineaPigId);
            if (healthChecks.Count < 0) return NoContent();
            return Ok(healthChecks);
        }

        [HttpPost]
        public async Task<IActionResult> InsertHealthCheck(HealthCheckDto healthCheckDto)
        {
            try
            {
                var newHealthCheck = await _service.InsertHealthCheckAsync(healthCheckDto);
                return Ok(newHealthCheck);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{healthCheckId:int}")]
        public async Task<IActionResult> UpdateHealthCheck(int healthCheckId, HealthCheckDto healthCheckDto)
        {
            try
            {
                if (healthCheckId != healthCheckDto.Id) return BadRequest("Falsche ID");
                var updatedHealthCheck = await _service.UpdateHealthCheckAsync(healthCheckId, healthCheckDto);
                return Ok(updatedHealthCheck);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{healthCheckId:int}")]
        public async Task<IActionResult> DeleteHealthCheck(int healthCheckId)
        {
            try
            {
                var checkDelete = await _service.DeleteHealthCheckAsync(healthCheckId);
                if (!checkDelete) return BadRequest("Konnte nicht gelöscht werden");
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
