
using API.Models;
using AutoMapper;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Controller]
    [Route("api/items")]
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        public ItemController(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_mapper.Map<IEnumerable<ItemInfo>>(_itemRepository.GetItems()));
        }

        [HttpGet("{id}",Name = "GetItem")]
        public IActionResult GetItem(int id)
        {
            try
            {
                return Ok(_mapper.Map<ItemInfo>(_itemRepository.GetItem(id)));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody]ItemToCreate item)
        {
            var itemToAdd = _mapper.Map<Item>(item);

            _itemRepository.AddItem(itemToAdd);

            var itemToReturn = _mapper.Map<ItemInfo>(itemToAdd);

            return CreatedAtRoute(
                "GetItem",
                new { itemToReturn.Id },
                itemToReturn);
        }
    }
}
