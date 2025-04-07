using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using PropertyPro.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Implementation
{
    public class ImageManagementService : IImageManagementService
    {
        private readonly IFileProvider _fileProvider;

        public ImageManagementService(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public async Task<List<string>> AddImagesAsync(IFormFileCollection files, string src)
        {
            var SaveImageSrc = new List<string>();

            var ImageDirctory = Path.Combine("wwwroot", "Images", "Units", src);
            if (Directory.Exists(ImageDirctory) is not true)
                Directory.CreateDirectory(ImageDirctory);

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    // Get Image name
                    var ImageName = file.FileName;
                    var ImageSrc = $"/Images/Units/{src}/{ImageName}";
                    // for save image in server
                    var root = Path.Combine(ImageDirctory, ImageName);
                    using (FileStream stream = new(root, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    SaveImageSrc.Add(ImageSrc);
                }
            }

            return SaveImageSrc;
        }

        public void DeleteImageAsync(string src)
        {
            var info = _fileProvider.GetFileInfo(src);
            if (info != null)
            {
                var root = info.PhysicalPath;
                File.Delete(root);
            }
        }

        public async Task<string> AddUserImageAsync(IFormFile file, string src)
        {
            var SaveImageSrc = "";

            var ImageDirctory = Path.Combine("wwwroot", "Images", "Users", src);
            if (Directory.Exists(ImageDirctory) is not true)
                Directory.CreateDirectory(ImageDirctory);

            
            if (file.Length > 0)
            {
                // Get Image name
                var ImageName = file.FileName;
                var ImageSrc = $"/Images/Users/{src}/{ImageName}";
                // for save image in server
                var root = Path.Combine(ImageDirctory, ImageName);
                using (FileStream stream = new(root, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                SaveImageSrc = ImageSrc;
            }

            return SaveImageSrc;
        }

    }
}
