using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Abstract
{
    public interface IImageManagementService
    {
        Task<string> AddUserImageAsync(IFormFile file, string src);
        Task<List<string>> AddImagesAsync(List<IFormFile> files, string src);
        void DeleteImageAsync(string src);

    }
}
