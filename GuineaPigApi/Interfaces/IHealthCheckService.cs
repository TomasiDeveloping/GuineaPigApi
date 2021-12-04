using GuineaPigApi.DTO_s;

namespace GuineaPigApi.Interfaces
{
    public interface IHealthCheckService
    {
        Task<List<HealthCheckDTO>> GetHealthChecksAsync();
        Task<List<HealthCheckDTO>> GetHealthChecksByGuinePigIdAsync(int guinePigId);
        Task<HealthCheckDTO> GetHealthCheckByIdAsync(int healthCheckId);
        Task<HealthCheckDTO> InsertHealthCheckAsync(HealthCheckDTO healthCheckDTO);
        Task<HealthCheckDTO> UpdateHealthCheckAsync(int healthCheckId, HealthCheckDTO healthCheck);
        Task<bool> DeleteHealthCheckAsync(int healthCheckId);

    }
}
