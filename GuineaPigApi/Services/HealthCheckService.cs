using AutoMapper;
using GuineaPigApi.Data;
using GuineaPigApi.DTOs;
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
        public async Task<List<HealthCheckDto>> GetHealthChecksAsync()
        {
            var healthChecks = await _context.HealthChecks
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<HealthCheckDto>>(healthChecks);
        }
        public async Task<HealthCheckDto> GetHealthCheckByIdAsync(int healthCheckId)
        {
            var healthCheck = await _context.HealthChecks
                .AsNoTracking()
                .FirstOrDefaultAsync(h => h.Id == healthCheckId);
            return _mapper.Map<HealthCheckDto>(healthCheck);
        }

        public async Task<List<HealthCheckDto>> GetHealthChecksByGuineaPigIdAsync(int guineaPigId)
        {
            var healthChecks = await _context.HealthChecks
                .AsNoTracking()
                .Where(h => h.GuineaPigId == guineaPigId)
                .OrderByDescending(h => h.HealthCheckDate)
                .Take(10)
                .ToListAsync();
            return _mapper.Map<List<HealthCheckDto>>(healthChecks);
        }

        public async Task<HealthCheckDto> InsertHealthCheckAsync(HealthCheckDto healthCheckDto)
        {
            var guineaPig = await _context.GuineaPigs.FirstOrDefaultAsync(g => g.Id == healthCheckDto.GuineaPigId);
            if (guineaPig != null) guineaPig.LastHealthCheck = DateTime.Now;
            var newHealthCheck = _mapper.Map<HealthCheck>(healthCheckDto);
            await _context.AddAsync(newHealthCheck);
            await _context.SaveChangesAsync();
            return _mapper.Map<HealthCheckDto>(newHealthCheck);
        }

        public async Task<HealthCheckDto?> UpdateHealthCheckAsync(int healthCheckId, HealthCheckDto healthCheckDto)
        {
            var healthCheckToUpdate = await _context.HealthChecks
                .FirstOrDefaultAsync(h => h.Id == healthCheckId);
            if (healthCheckToUpdate == null) return null;
            _mapper.Map(healthCheckDto, healthCheckToUpdate);
            await _context.SaveChangesAsync();
            return _mapper.Map<HealthCheckDto>(healthCheckToUpdate);
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
