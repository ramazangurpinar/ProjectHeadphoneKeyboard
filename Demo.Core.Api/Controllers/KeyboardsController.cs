using Demo.Core.Application.DTOs;
using Demo.Core.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Core.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeyboardsController : ControllerBase
    {
        private readonly IKeyboardService _keyboardService;

        public KeyboardsController(IKeyboardService keyboardService)
        {
            _keyboardService = keyboardService;
        }

        // GET: api/keyboards
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var keyboards = await _keyboardService.GetAllAsync();
            return Ok(keyboards);
        }

        // GET: api/keyboards/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var keyboard = await _keyboardService.GetByIdAsync(id);
            if (keyboard == null)
                return NotFound();

            return Ok(keyboard);
        }

        // POST: api/keyboards
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] KeyboardCreateDto dto)
        {
            var id = await _keyboardService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        // PUT: api/keyboards/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] KeyboardUpdateDto dto)
        {
            var updated = await _keyboardService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/keyboards/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _keyboardService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
