using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TEntity, TDto> (IRepository<TEntity> repository, IMapper mapper) : ControllerBase where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository = repository;
        protected readonly IMapper _mapper = mapper;

        [HttpPost]
        public virtual async Task<ActionResult<TDto>> Add(TDto gameDto, CancellationToken cts)
        {
            if (gameDto == null)
                return BadRequest();

            var entity = _mapper.Map<TEntity>(gameDto);
            await _repository.Add(entity, cts);
            return NoContent(); 
        }

        [HttpGet("{id:int}")]
        public virtual async Task<ActionResult<TDto>> Get(int id, CancellationToken ct)
        {
            var entity = await _repository.Get(id, ct);
            if (entity == null)
                return NotFound();

            return Ok(_mapper.Map<TDto>(entity));
        }

        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            await _repository.Delete(id, ct);
            return NoContent();
        }
    }
}