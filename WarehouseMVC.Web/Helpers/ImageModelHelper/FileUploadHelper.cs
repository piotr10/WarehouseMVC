using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using WarehouseMVC.Application.ViewModel.Image;
using WarehouseMVC.Infrastructure;

namespace WarehouseMVC.Web.Helpers.ImageModelHelper
{
    public class FileUploadHelper
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileUploadHelper(Context context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public void FileH(NewImageModelVm imageModel, IFormFile[] attachments)
        {
            //Save image to Image folder
            List<string> fileNames = null;
            if (attachments != null && attachments.Length > 0)
            {
                fileNames = new List<string>();
                foreach (IFormFile attachment in attachments)
                {
                    string fileName = Path.GetFileNameWithoutExtension(attachment.FileName);
                    string extension = Path.GetExtension(attachment.FileName);
                    imageModel.ImageName = fileName = fileName + DateTime.Now.ToString("yy-MM-dd") + extension;
                    string path = Path.Combine(_webHostEnvironment.WebRootPath + @"\Image\", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        attachment.CopyToAsync(stream);
                    }

                    fileNames.Add(path);
                }
            }
            else
            {
                imageModel.ImageName = "No_Attachment" + ".xyz";
            }
        }
    }
}