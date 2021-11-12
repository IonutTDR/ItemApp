using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/items/{itemId}/comments")]
    [Controller]
    public class CommentController : Controller
    {
        private IItemService _itemService;
        private IMapper _mapper;

        public CommentController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetComments(int itemId)
        {
            try
            {
                var comments = _mapper.Map<IEnumerable<ViewModels.Comment>>(_itemService.GetCommentsForItem(itemId));
                return Ok(comments);
            }
            catch(Exception e)
            {
                return BadRequest(Json(new { status = "Error", message = e.Message }));
            }
        }
        [HttpGet("{id}", Name = "GetComment")]
        public IActionResult GetComment(int itemId, int id)
        {
            try
            {
                var comment = _mapper.Map<ViewModels.Comment>(_itemService.GetCommentForItem(itemId, id));
                return Ok(comment);
            }
            catch (Exception e)
            {

                return BadRequest(Json(new { status = "Error", message = e.Message }));
            }
        }
        [HttpPost]
        public IActionResult CreateComment(int itemId, [FromBody]ViewModels.CommentToCreate comment)
        {
            try
            {
                var commentToCreate = _mapper.Map<Services.Models.CommentToCreate>(comment);
                

                var commentToReturn = _mapper.Map<ViewModels.Comment>(_itemService.AddComment(itemId, commentToCreate));

                return CreatedAtRoute(
                    "GetComment",
                    new { itemId, commentToReturn.Id },
                    commentToReturn);
            }
            catch (Exception e)
            {

                return BadRequest(Json(new { status = "Error", message = e.Message }));
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateComment(int itemId, int id, [FromBody]ViewModels.CommentToUpdate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var commentToUpdate = _mapper.Map<Services.Models.CommentToUpdate>(comment);
                _itemService.UpdateComment(itemId, id, commentToUpdate);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(Json(new { status = "Error", message = e.Message }));
            }

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int itemId, int id)
        {
            try
            {
                _itemService.DeleteComment(itemId, id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(Json(new { status = "Error", message = e.Message }));
            }
        }
    }
}
