
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Dtos;
using System;
using System.Linq;


namespace Catalog.Controllers
{
   
    [ApiController]
     [Route("items")]
    public class ItemsController : ControllerBase
    {
         private readonly IInMemoryItemsRepository _repository;
        public ItemsController(IInMemoryItemsRepository repository)
        {
            _repository = repository;
        }
         [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items= _repository.GetItems().Select(a=>a.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = _repository.GetItem(id).AsDto();
            if(item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
