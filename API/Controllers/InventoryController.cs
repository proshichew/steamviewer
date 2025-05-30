using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.DTO;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController(IInventoryRepository repository, IMapper mapper, IInventoryService service)
        : BaseController<Domain.Entities.Inventory, InventoryDto>(repository, mapper)
    {
        private readonly IInventoryService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryDto>>> GetAll(CancellationToken cts)
        {
            var inventories = await _service.GetAllAsync(cts);

            var inventoryDtos = _mapper.Map<IEnumerable<InventoryDto>>(inventories);
            return Ok(inventoryDtos);
        }

        [HttpGet("{playerId}")]
        public async Task<ActionResult<InventoryDto>> GetByPlayerId(string playerId, CancellationToken cts)
        {
            var inventory = await _service.GetByPlayerIdAsync(playerId, cts);

            var inventoryDto = _mapper.Map<InventoryDto>(inventory);
            return Ok(inventoryDto);
        }

        [HttpPost("create")]
        public async Task<ActionResult<InventoryDto>> CreateInventory([FromBody] string playerId, CancellationToken cts)
        {
            if (string.IsNullOrEmpty(playerId))
                return BadRequest("Player ID cannot be null or empty.");
            var inventory = await _service.CreateInventoryAsync(playerId, cts);
            if (inventory == null)
                return NotFound($"Inventory for player {playerId} not found.");
            var inventoryDto = _mapper.Map<InventoryDto>(inventory);
            return Ok(inventoryDto);
        }

        [HttpGet("{inventoryId}/items")]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItems(int inventoryId, CancellationToken cts)
        {
            var items = await _service.GetItemsAsync(inventoryId, cts);
            if (items == null || !items.Any())
                return NotFound($"No items found for inventory ID {inventoryId}.");
            var itemDtos = _mapper.Map<IEnumerable<ItemDto>>(items);
            return Ok(itemDtos);
        }
    }
}
