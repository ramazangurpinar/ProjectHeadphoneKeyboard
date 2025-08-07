using Demo.Core.Application.DTOs;
using Demo.Core.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Core.Api.Controllers
{
    public class HeadphonesController : BaseProductController<IHeadphoneService, HeadphoneCreateDto, HeadphoneUpdateDto, HeadphoneDto>
    {
        public HeadphonesController(IHeadphoneService service) : base(service) { }

        public override async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        public override async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        public override async Task<IActionResult> Create([FromBody] HeadphoneCreateDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        public override async Task<IActionResult> Update(int id, [FromBody] HeadphoneUpdateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        public override async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
