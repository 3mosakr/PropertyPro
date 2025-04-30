using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyPro.Api.Base;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Comments;
using System.Security.Claims;

namespace PropertyPro.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin, User")]

    public class CommentsController : AppControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly ILogger<CommentsController> _logger;

        public CommentsController(ICommentService commentService, ILogger<CommentsController> logger)
        {
            _commentService = commentService;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> AddCommentAsync(AddCommentDto comment)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is adding a comment.");
            var response = await _commentService.AddCommentAsync(comment);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                _logger.LogInformation($"Comment added successfully by {username}.");
            }
            else
            {
                _logger.LogWarning($"Failed to add comment by {username}. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCommentAsync(int commentId)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is deleting a comment with ID {commentId}.");
            var response = await _commentService.DeleteCommentAsync(commentId);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"Comment with ID {commentId} deleted successfully by {username}.");
            }
            else
            {
                _logger.LogWarning($"Failed to delete comment with ID {commentId} by {username}. Error: {response.Message}");
            }
            return NewResult(response);
        }
    }
}
