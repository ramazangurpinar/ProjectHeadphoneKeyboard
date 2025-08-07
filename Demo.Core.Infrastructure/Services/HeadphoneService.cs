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
    public class HeadphoneService : IHeadphoneService
    {
        private readonly ApplicationDbContext _context;

        public HeadphoneService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HeadphoneDto>> GetAllAsync()
        {
            return await _context.Products
                .OfType<Headphone>()
                .Select(h => new HeadphoneDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    Description = h.Description,
                    Price = h.Price,
                    ImageFileName = h.ImageFileName,
                    Wireless = h.Wireless,
                    Weight = h.Weight,
                    Manufacturer = h.Manufacturer,
                    BatteryLife = h.BatteryLife,
                    NoiseCancellationType = h.NoiseCancellationType,
                    Mic = h.Mic,
                })
                .ToListAsync();
        }

        public async Task<HeadphoneDto?> GetByIdAsync(int id)
        {
            var h = await _context.Products
                .OfType<Headphone>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (h == null) return null;

            return new HeadphoneDto
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                Price = h.Price,
                ImageFileName = h.ImageFileName,
                Wireless = h.Wireless,
                Weight = h.Weight,
                Manufacturer = h.Manufacturer,
                BatteryLife = h.BatteryLife,
                NoiseCancellationType = h.NoiseCancellationType,
                Mic = h.Mic,
            };
        }

        public async Task<HeadphoneDto> CreateAsync(HeadphoneCreateDto dto)
        {
            var headphone = new Headphone
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                ImageFileName = dto.ImageFileName,
                Wireless = dto.Wireless,
                Weight = dto.Weight,
                Manufacturer = dto.Manufacturer,
                BatteryLife = dto.BatteryLife,
                NoiseCancellationType = dto.NoiseCancellationType,
                Mic = dto.Mic,
                ProductType = ProductTypeEnum.Headphone.GetEnumMemberValue()
            };

            _context.Products.Add(headphone);
            await _context.SaveChangesAsync();

            return new HeadphoneDto
            {
                Id = headphone.Id,
                Name = headphone.Name,
                Description = headphone.Description,
                Price = headphone.Price,
                ImageFileName = headphone.ImageFileName,
                Wireless = headphone.Wireless,
                Weight = headphone.Weight,
                Manufacturer = headphone.Manufacturer,
                BatteryLife = headphone.BatteryLife,
                NoiseCancellationType = headphone.NoiseCancellationType,
                Mic = headphone.Mic,
            };
        }

        public async Task<bool> UpdateAsync(int id, HeadphoneUpdateDto dto)
        {
            var headphone = await _context.Products
                .OfType<Headphone>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (headphone == null) return false;

            headphone.Name = dto.Name;
            headphone.Description = dto.Description;
            headphone.Price = dto.Price;
            headphone.ImageFileName = dto.ImageFileName;
            headphone.Wireless = dto.Wireless;
            headphone.Weight = dto.Weight;
            headphone.Manufacturer = dto.Manufacturer;
            headphone.BatteryLife = dto.BatteryLife;
            headphone.NoiseCancellationType = dto.NoiseCancellationType;
            headphone.Mic = dto.Mic;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var headphone = await _context.Products
                .OfType<Headphone>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (headphone == null) return false;

            _context.Products.Remove(headphone);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
