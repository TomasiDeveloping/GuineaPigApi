using AutoMapper;
using GuineaPigApi.Data;
using GuineaPigApi.DTOs;
using GuineaPigApi.Interfaces;
using GuineaPigApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GuineaPigApi.Services
{
    public class GuineaPigService : IGuineaPigService
    {
        private readonly GuineaPigContext _context;
        private readonly IMapper _mapper;
        public GuineaPigService(GuineaPigContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GuineaPigDto>> GetGuineaPigsAsync()
        {
            var guineaPigs = await _context.GuineaPigs
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<GuineaPigDto>>(guineaPigs);
        }

        public async Task<GuineaPigDto?> GetGuineaPigByIdAsync(int guineaPigId)
        {
            var guineaPig = await _context.GuineaPigs
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == guineaPigId);
            return guineaPig == null ? null : _mapper.Map<GuineaPigDto>(guineaPig);
        }

        public async Task<GuineaPigDto?> InsertGuineaPigAsync(GuineaPigDto? guineaPigDto)
        {
            if (guineaPigDto == null) return null;
            var guineaPig = _mapper.Map<GuineaPig>(guineaPigDto);
            await _context.GuineaPigs.AddAsync(guineaPig);
            await _context.SaveChangesAsync();
            return _mapper.Map<GuineaPigDto>(guineaPig);
        }

        public async Task<GuineaPigDto?> UpdateGuineaPigAsync(int guineaPigId, GuineaPigDto guineaPigDto)
        {
            var guineaPig = await _context.GuineaPigs
                .FirstOrDefaultAsync(g => g.Id == guineaPigId);
            if (guineaPig == null) return null;
            _mapper.Map(guineaPigDto, guineaPig);
            await _context.SaveChangesAsync();
            return _mapper.Map<GuineaPigDto>(guineaPig);
        }

        public async Task<bool> DeleteGuineaPigAsync(int guineaPigId)
        {
            var guineaPig = await _context.GuineaPigs.FirstOrDefaultAsync(g => g.Id == guineaPigId);
            if (guineaPig == null) return false;
            _context.GuineaPigs.Remove(guineaPig);
            await _context.SaveChangesAsync();
            return true;
        } 
    }
}
