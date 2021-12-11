using GuineaPigApi.DTOs;

namespace GuineaPigApi.Interfaces
{
    public interface IGuineaPigService
    {
        Task<List<GuineaPigDto>> GetGuineaPigsAsync();
        Task<GuineaPigDto?> GetGuineaPigByIdAsync(int guineaPigId);
        Task<GuineaPigDto?> InsertGuineaPigAsync(GuineaPigDto? guineaPigDto);
        Task<GuineaPigDto?> UpdateGuineaPigAsync(int guineaPigId, GuineaPigDto guineaPigDto);
        Task<bool> DeleteGuineaPigAsync(int guineaPigId);
    }
}
