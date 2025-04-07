using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyPro.Api.Base;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Comments;

namespace PropertyPro.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin, User")]

    public class CommentsController : AppControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpPost]
        public async Task<IActionResult> AddCommentAsync(AddCommentDto comment)
        {
            var response = await _commentService.AddCommentAsync(comment);
            return NewResult(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCommentAsync(int commentId)
        {
            var response = await _commentService.DeleteCommentAsync(commentId);
            return NewResult(response);
        }
    }
}
