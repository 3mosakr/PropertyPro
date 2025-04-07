using AutoMapper;
using Microsoft.AspNetCore.Http;
using PropertyPro.Data.Models;
using PropertyPro.Infrastructure.Reposatories.Abstraction;
using PropertyPro.Infrastructure.Responses;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<Comment>> AddCommentAsync(AddCommentDto comment)
        {
            // validate input
            try
            {
                // mapping
                var mappedComment = _mapper.Map<Comment>(comment);
                // Set UserId to Comment
                int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                mappedComment.UserId = userId;
                // set Date
                mappedComment.CommentDate = DateTime.Now;
                // add operation
                var result = await _unitOfWork.Comments.AddAsync(mappedComment);
                // return response
                if (result != null)
                    return new ResponseModel<Comment>([result], "Comment Added successfully");
                return new ResponseModel<Comment>("Comment didn't added please try again later", false);
            }
            catch (Exception ex)
            {
                return new ResponseModel<Comment>
                {
                    Status = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    Errors = [ex.ToString()]
                };
            }

        }


        public async Task<ResponseModel<Comment>> DeleteCommentAsync(int id)
        {
            try
            {
                // Check if comment exist with id
                var comment = await _unitOfWork.Comments.GetByIdAsync(id);
                if (comment != null)
                {
                    // check comment owner
                    // user Id
                    int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                    var isAdmin = _httpContextAccessor.HttpContext.User.HasClaim(ClaimTypes.Role, "Admin");
                    
                    if (userId == comment.UserId || isAdmin)
                    {
                        await _unitOfWork.Comments.DeleteAsync(comment);
                        return new ResponseModel<Comment>([comment], "Comment deleted successfully.");
                    }
                    else
                    {
                        // Unauthorized
                        return new ResponseModel<Comment>
                        {
                            Status = false,
                            StatusCode = System.Net.HttpStatusCode.Unauthorized,
                            Message = "You have no access to delete comment."
                        };
                    }
                    
                }
                return new ResponseModel<Comment>{
                    Status = false,
                    StatusCode= System.Net.HttpStatusCode.NotFound,
                    Message = "Comment Not Found."
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<Comment>
                {
                    Status = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    Errors = [ex.ToString()]
                };
            }
        }
    }
}
