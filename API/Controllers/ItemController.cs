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
                return BadRequest(Json(new { status = "Error", message = e.Message }));
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

                return BadRequest(Json(new { status = "Error", message = e.Message }));
            }
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] ViewModels.ItemToCreate item)
        {
            if (!ModelState.IsValid)
                return BadRequest();

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
                return BadRequest(Json(new { status = "Error", message = e.Message }));
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] ViewModels.ItemToUpdate item)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var itemToUpdate = _mapper.Map<Services.Models.ItemToUpdate>(item);
                _itemService.UpdateItem(id, itemToUpdate);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(Json(new { status = "Error", message = e.Message }));
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

                return BadRequest(Json(new { status = "Error", message = e.Message }));
            }
        }
    }
}
