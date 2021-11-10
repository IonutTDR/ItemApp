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
                return Json(new { status = "error", message = "error creating comment" + e.ToString() });
            }
        }
        [HttpPost]
        public IActionResult CreateComment(int itemId, [FromBody]ViewModels.CommentToCreate comment)
        {
            try
            {
                var commentToCreate = _mapper.Map<Services.Models.CommentToCreate>(comment);
                

                var commentToReturn = _mapper.Map<ViewModels.Comment>(_itemService.AddComment(itemId, commentToCreate));

                return Ok(commentToReturn);
            }
            catch (Exception e)
            {

                return Json(new { status = "error", message = "error creating comment" + e.ToString()});
            }
        }
    }
}
