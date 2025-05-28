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

        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            await _repository.Delete(id, ct);
            return NoContent();
        }
    }
}