using AutoMapper;
using GuineaPigApi.Data;
using GuineaPigApi.DTO_s;
using GuineaPigApi.Interfaces;
using GuineaPigApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GuineaPigApi.Services
{
    public class HealthCheckService : IHealthCheckService
    {
        private readonly GuineaPigContext _context;
        private readonly IMapper _mapper;
        public HealthCheckService(GuineaPigContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<HealthCheckDTO>> GetHealthChecksAsync()
        {
            var healthChecks = await _context.HealthChecks
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<HealthCheckDTO>>(healthChecks);
        }
        public async Task<HealthCheckDTO> GetHealthCheckByIdAsync(int healthCheckId)
        {
            var healthCheck = await _context.HealthChecks
                .AsNoTracking()
                .FirstOrDefaultAsync(h => h.Id == healthCheckId);
            return _mapper.Map<HealthCheckDTO>(healthCheck);
        }

        public async Task<List<HealthCheckDTO>> GetHealthChecksByGuinePigIdAsync(int guinePigId)
        {
            var healthChecks = await _context.HealthChecks
                .AsNoTracking()
                .Where(h => h.GuineaPigId == guinePigId)
                .OrderByDescending(h => h.HealthCheckDate)
                .Take(10)
                .ToListAsync();
            return _mapper.Map<List<HealthCheckDTO>>(healthChecks);
        }

        public async Task<HealthCheckDTO> InsertHealthCheckAsync(HealthCheckDTO healthCheckDTO)
        {
            var guineaPig = await _context.GuineaPigs.FirstOrDefaultAsync(g => g.Id == healthCheckDTO.GuineaPigId);
            guineaPig.LastHealthCheck = DateTime.Now;
            var newHealthCheck = _mapper.Map<HealthCheck>(healthCheckDTO);
            await _context.AddAsync(newHealthCheck);
            await _context.SaveChangesAsync();
            return _mapper.Map<HealthCheckDTO>(newHealthCheck);
        }

        public async Task<HealthCheckDTO> UpdateHealthCheckAsync(int healthCheckId, HealthCheckDTO healthCheckDTO)
        {
            var healthCheckToUpdate = await _context.HealthChecks
                .FirstOrDefaultAsync(h => h.Id == healthCheckId);
            if (healthCheckToUpdate == null) return null;
            _mapper.Map<HealthCheckDTO, HealthCheck>(healthCheckDTO, healthCheckToUpdate);
            await _context.SaveChangesAsync();
            return _mapper.Map<HealthCheckDTO>(healthCheckToUpdate);
        }

        public async Task<bool> DeleteHealthCheckAsync(int healthCheckId)
        {
            var healthCheckToDelete = await _context.HealthChecks
                .FirstOrDefaultAsync(h => h.Id == healthCheckId);
            if (healthCheckToDelete == null) return false;
            _context.HealthChecks.Remove(healthCheckToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
