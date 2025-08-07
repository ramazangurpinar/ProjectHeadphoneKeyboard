using Demo.Core.Application.DTOs;
using Demo.Core.Application.Interfaces;
using Demo.Core.Domain.Entities;
using Demo.Core.Domain.Enums;
using Demo.Core.Domain.Utils;
using Demo.Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Runtime.Serialization;

namespace Demo.Core.Infrastructure.Services
{
    public class KeyboardService : IKeyboardService
    {
        private readonly ApplicationDbContext _context;

        public KeyboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<KeyboardDto>> GetAllAsync()
        {
            return await _context.Products
                .OfType<Keyboard>()
                .Select(h => new KeyboardDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    Description = h.Description,
                    Price = h.Price,
                    ImageFileName = h.ImageFileName,
                    Wireless = h.Wireless,
                    Weight = h.Weight,
                    IsMechanical = h.IsMechanical
                })
                .ToListAsync();
        }

        public async Task<KeyboardDto?> GetByIdAsync(int id)
        {
            var h = await _context.Products
                .OfType<Keyboard>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (h == null) return null;

            return new KeyboardDto
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                Price = h.Price,
                ImageFileName = h.ImageFileName,
                Wireless = h.Wireless,
                Weight = h.Weight,
                IsMechanical = h.IsMechanical
            };
        }

        public async Task<KeyboardDto> CreateAsync(KeyboardCreateDto dto)
        {
            var keyboard = new Keyboard
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                ImageFileName = dto.ImageFileName,
                Wireless = dto.Wireless,
                Weight = dto.Weight,
                IsMechanical = dto.IsMechanical,
                ProductType = ProductTypeEnum.Keyboard.GetEnumMemberValue()
            };

            _context.Products.Add(keyboard);
            await _context.SaveChangesAsync();

            return new KeyboardDto
            {
                Id = keyboard.Id,
                Name = keyboard.Name,
                Description = keyboard.Description,
                Price = keyboard.Price,
                ImageFileName = keyboard.ImageFileName,
                Wireless = keyboard.Wireless,
                Weight = keyboard.Weight,
                IsMechanical = keyboard.IsMechanical
            };
        }

        public async Task<bool> UpdateAsync(int id, KeyboardUpdateDto dto)
        {
            var headphone = await _context.Products
                .OfType<Keyboard>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (headphone == null) return false;

            headphone.Name = dto.Name;
            headphone.Description = dto.Description;
            headphone.Price = dto.Price;
            headphone.ImageFileName = dto.ImageFileName;
            headphone.Wireless = dto.Wireless;
            headphone.Weight = dto.Weight;
            headphone.IsMechanical = dto.IsMechanical;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var headphone = await _context.Products
                .OfType<Keyboard>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (headphone == null) return false;

            _context.Products.Remove(headphone);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
