using AutoMapper;
using GuineaPigApi.Data;
using GuineaPigApi.DTO_s;
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

        public async Task<List<GuineaPigDTO>> GetGuineaPigsAsync()
        {
            var guineaPigs = await _context.GuineaPigs
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<GuineaPigDTO>>(guineaPigs);
        }

        public async Task<GuineaPigDTO> GetGuineaPigByIdAsync(int guineaPigId)
        {
            var guineaPig = await _context.GuineaPigs
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == guineaPigId);
            if (guineaPig == null) return null;
            return _mapper.Map<GuineaPigDTO>(guineaPig);
        }

        public async Task<GuineaPigDTO> InsertGuineaPigAsync(GuineaPigDTO guineaPigDTO)
        {
            if (guineaPigDTO == null) return null;
            var guineaPig = _mapper.Map<GuineaPig>(guineaPigDTO);
            await _context.GuineaPigs.AddAsync(guineaPig);
            await _context.SaveChangesAsync();
            return _mapper.Map<GuineaPigDTO>(guineaPig);
        }

        public async Task<GuineaPigDTO> UpdateGuineaPigAsync(int guineaPigId, GuineaPigDTO guineaPigDTO)
        {
            var guineaPig = await _context.GuineaPigs
                .FirstOrDefaultAsync(g => g.Id == guineaPigId);
            if (guineaPig == null) return null;
            _mapper.Map<GuineaPigDTO, GuineaPig>(guineaPigDTO, guineaPig);
            await _context.SaveChangesAsync();
            return _mapper.Map<GuineaPigDTO>(guineaPig);
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
