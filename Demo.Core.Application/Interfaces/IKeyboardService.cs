using Demo.Core.Application.DTOs;

namespace Demo.Core.Application.Interfaces
{
    public interface IKeyboardService
    {
        Task<List<KeyboardDto>> GetAllAsync();
        Task<KeyboardDto?> GetByIdAsync(int id);
        Task<KeyboardDto> CreateAsync(KeyboardCreateDto dto);
        Task<bool> UpdateAsync(int id, KeyboardUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
