
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Dtos;
using System;
using System.Linq;
using Catalog.Entities;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
   
    [ApiController]
     [Route("items")]
    public class ItemsController : ControllerBase
    {
         private readonly IItemsRepository _repository;
        public ItemsController(IItemsRepository repository)
        {
            _repository = repository;
        }
         [HttpGet]
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            var items= (await _repository.GetItemsAsync()).Select(item=>item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item =await _repository.GetItemAsync(id);
            if(item is null)
            {
                return NotFound();
            }
            return item.AsDto();
        }
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAysnc(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            await _repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto()) ; 

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id,UpdateItemDto itemDto)
        {

            var existingItem =await _repository.GetItemAsync(id);
            if(existingItem is null)
            {
                return NotFound();
            }
            Item updateItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };
            await _repository.UpdateItemAsync(updateItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var existingItem =await _repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }            
            await _repository.DeleteItemAsync(id);
            return NoContent();
        }
    }
}
