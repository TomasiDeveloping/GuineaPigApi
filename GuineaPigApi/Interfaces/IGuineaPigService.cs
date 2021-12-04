using GuineaPigApi.DTO_s;

namespace GuineaPigApi.Interfaces
{
    public interface IGuineaPigService
    {
        Task<List<GuineaPigDTO>> GetGuineaPigsAsync();
        Task<GuineaPigDTO> GetGuineaPigByIdAsync(int guineaPigId);
        Task<GuineaPigDTO> InsertGuineaPigAsync(GuineaPigDTO guineaPigDTO);
        Task<GuineaPigDTO> UpdateGuineaPigAsync(int guineaPigId, GuineaPigDTO guineaPigDTO);
        Task<bool> DeleteGuineaPigAsync(int guineaPigId);
    }
}
