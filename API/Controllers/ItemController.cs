using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/items")]
    [Controller]
    public class ItemController : Controller
    {
        private IItemService _itemService;
        private IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            try
            {
                var items = _mapper.Map<IEnumerable<ViewModels.Item>>(_itemService.GetItems());
                return Ok(items);
            }
            catch(Exception e)
            {
                return Json(new { status = "error", message = "error creating customer" + e.Message });
            }
        }
        [HttpGet("{id}", Name = "GetItem")]
        public IActionResult GetItem(int id)
        {
            try
            {
                var item = _mapper.Map<ViewModels.Item>(_itemService.GetItem(id));
                return Ok(item);
            }
            catch (Exception e)
            {

                return Json(new { status = "error", message = "error creating customer" + e.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] ViewModels.ItemToCreate item)
        {
            try
            {
                var itemToAddInService = _mapper.Map<Services.Models.ItemToCreate>(item);

                var itemToReturn =_mapper.Map<ViewModels.Item>(_itemService.AddItem(itemToAddInService));

                return CreatedAtRoute(
                    "GetItem",
                    new { itemToReturn.Id },
                    itemToReturn);
            }
            catch(Exception e)
            {
                return Json(new { status = "error", message = "error creating customer" + e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            try
            {
                _itemService.DeleteItem(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return Json(new { status = "error", message = "error creating customer" + e.Message });
            }
        }
    }
}
