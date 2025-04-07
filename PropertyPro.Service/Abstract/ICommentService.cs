using Microsoft.AspNetCore.Http;
using PropertyPro.Data.Models;
using PropertyPro.Infrastructure.Responses;
using PropertyPro.Service.Dto.Comments;
using PropertyPro.Service.Dto.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Abstract
{
    public interface ICommentService
    {

        public Task<ResponseModel<Comment>> AddCommentAsync(AddCommentDto comment);

        /// <summary>
        /// Only System Admin and Comment Owner Can delete it
        /// </summary>
        public Task<ResponseModel<Comment>> DeleteCommentAsync(int id);

    }
}
