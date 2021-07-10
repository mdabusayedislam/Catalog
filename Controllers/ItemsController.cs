
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Entities;
using System;

namespace Catalog.Controllers
{
   
    [ApiController]
     [Route("items")]
    public class ItemsController : ControllerBase
    {
         private readonly InMemoryItemsRepository repository;
        public ItemsController()
        {
            repository = new InMemoryItemsRepository();
        }
          [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items= repository.GetItems();
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item= repository.GetItem(id);
            if(item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
