using GuineaPigApi.DTOs;

namespace GuineaPigApi.Interfaces
{
    public interface IHealthCheckService
    {
        Task<List<HealthCheckDto>> GetHealthChecksAsync();
        Task<List<HealthCheckDto>> GetHealthChecksByGuineaPigIdAsync(int guineaPigId);
        Task<HealthCheckDto> GetHealthCheckByIdAsync(int healthCheckId);
        Task<HealthCheckDto> InsertHealthCheckAsync(HealthCheckDto healthCheckDto);
        Task<HealthCheckDto?> UpdateHealthCheckAsync(int healthCheckId, HealthCheckDto healthCheck);
        Task<bool> DeleteHealthCheckAsync(int healthCheckId);

    }
}
