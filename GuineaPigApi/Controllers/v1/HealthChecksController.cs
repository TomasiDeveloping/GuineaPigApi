using GuineaPigApi.DTO_s;
using GuineaPigApi.Interfaces;
using Microsoft.AspNetCore.Http;
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
            if (healthCheck == null) return NotFound($"Kein Check gefunden mit der ID: {healthCheckId}");
            return Ok(healthCheck);
        }

        [HttpGet("guineaPig/{guineaPigId:int}")]
        public async Task<IActionResult> GetHealthChecksByGuineaPigId(int guineaPigId)
        {
            var healthChecks = await _service.GetHealthChecksByGuinePigIdAsync(guineaPigId);
            if (healthChecks.Count() < 0) return NoContent();
            return Ok(healthChecks);
        }

        [HttpPost]
        public async Task<IActionResult> InsertHealthCheck(HealthCheckDTO healthCheckDTO)
        {
            try
            {
                var newHealthCheck = await _service.InsertHealthCheckAsync(healthCheckDTO);
                return Ok(newHealthCheck);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{healthCheckId:int}")]
        public async Task<IActionResult> UpdateHealthCheck(int healthCheckId, HealthCheckDTO healthCheckDTO)
        {
            try
            {
                if (healthCheckId != healthCheckDTO.Id) return BadRequest("Falsche ID");
                var updatedHealthCheck = await _service.UpdateHealthCheckAsync(healthCheckId, healthCheckDTO);
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
