using Microsoft.AspNetCore.Mvc;

namespace Demo.Core.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseProductController<TService, TCreateDto, TUpdateDto, TDto> : ControllerBase
        where TService : class
    {
        protected readonly TService _service;

        protected BaseProductController(TService service)
        {
            _service = service;
        }

        [HttpGet]
        public abstract Task<IActionResult> GetAll();

        [HttpGet("{id}")]
        public abstract Task<IActionResult> GetById(int id);

        [HttpPost]
        public abstract Task<IActionResult> Create([FromBody] TCreateDto dto);

        [HttpPut("{id}")]
        public abstract Task<IActionResult> Update(int id, [FromBody] TUpdateDto dto);

        [HttpDelete("{id}")]
        public abstract Task<IActionResult> Delete(int id);
    }
}
