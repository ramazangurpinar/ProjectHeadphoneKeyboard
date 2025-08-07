using Demo.Core.Application.DTOs;
using Demo.Core.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Core.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeadphonesController : ControllerBase
    {
        private readonly IHeadphoneService _headphoneService;

        public HeadphonesController(IHeadphoneService headphoneService)
        {
            _headphoneService = headphoneService;
        }

        // GET: api/headphones
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var headphones = await _headphoneService.GetAllAsync();
            return Ok(headphones);
        }

        // GET: api/headphones/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var headphone = await _headphoneService.GetByIdAsync(id);
            if (headphone == null)
                return NotFound();

            return Ok(headphone);
        }

        // POST: api/headphones
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HeadphoneCreateDto dto)
        {
            var id = await _headphoneService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        // PUT: api/headphones/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HeadphoneUpdateDto dto)
        {
            var updated = await _headphoneService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/headphones/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _headphoneService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
