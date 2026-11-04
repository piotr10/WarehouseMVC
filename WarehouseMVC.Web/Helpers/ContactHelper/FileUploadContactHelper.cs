using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using WarehouseMVC.Domain.Model;
using WarehouseMVC.Infrastructure;
using WarehouseMVC.Web.Helpers.ImageModelHelper;

namespace WarehouseMVC.Web.Helpers.ContactHelper
{
    public class FileUploadContactHelper
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public FileUploadContactHelper(Context context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        public int FileH(Contact contact, IFormFile[] attachments)
        {
            List<string> fileNames = null;
            if (attachments != null && attachments.Length > 0)
            {
                fileNames = new List<string>();
                foreach (IFormFile attachment in attachments)
                {
                    string fileName = Path.GetFileNameWithoutExtension(attachment.FileName);
                    string extension = Path.GetExtension(attachment.FileName);
                    contact.ImageName = fileName = fileName + DateTime.Now.ToString("yy-MM-dd") + extension;
                    string path = Path.Combine(_webHostEnvironment.WebRootPath + @"\ImageContact\", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        attachment.CopyTo(stream);
                        stream.Close();
                    }

                    fileNames.Add(path);
                }

                var body = "Name: " + contact.Name +
                           "<br>Surname: " + contact.Surname +
                           "<br>Address: " + contact.Address +
                           "<br> Email: " + contact.Email +
                           "<br> Phone: " + contact.Phone + "<br>";

                var mailHelper = new MailHelpersOutlook(_configuration);

                if (mailHelper.Send(_configuration["Outlook:Username"], _configuration["Outlook:Username"], contact.Subject, body, fileNames))
                {
                    contact.AddFrom = "Added from mail";
                    _context.Add(contact);
                    _context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 2;
                }
            }

            return 0;
        }
    }
}