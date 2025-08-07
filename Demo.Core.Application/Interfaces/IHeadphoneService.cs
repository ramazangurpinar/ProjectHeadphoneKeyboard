using Demo.Core.Application.DTOs;

namespace Demo.Core.Application.Interfaces
{
    public interface IHeadphoneService
    {
        Task<List<HeadphoneDto>> GetAllAsync();
        Task<HeadphoneDto?> GetByIdAsync(int id);
        Task<HeadphoneDto> CreateAsync(HeadphoneCreateDto dto);
        Task<bool> UpdateAsync(int id, HeadphoneUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
