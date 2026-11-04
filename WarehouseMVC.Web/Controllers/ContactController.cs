using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using GroupDocs.Viewer.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WarehouseMVC.Application.Interfaces;
using WarehouseMVC.Domain.Model;
using WarehouseMVC.Infrastructure;
using WarehouseMVC.Web.Helpers;
using WarehouseMVC.Web.Helpers.ContactHelper;
using WarehouseMVC.Web.Helpers.ImageModelHelper;
using WarehouseMVC.Web.Models;

namespace WarehouseMVC.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly IWebHostEnvironment _hostEnvironment;
        private readonly IContactService _contactService;

        public ContactController(IConfiguration configuration, IWebHostEnvironment webHostEnvironment, Context context, IWebHostEnvironment hostEnvironment, IContactService contactService)
        {
            _context = context;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _hostEnvironment = hostEnvironment;
            _contactService = contactService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Recruitment")]
        public IActionResult Index(int pageSize = 10, int page = 1, string searchFilter = "")
        {
            var model = _contactService.GetAllContactForList(pageSize, page, searchFilter);
            return View(model);
        }

        [Authorize(Roles = "Admin, Recruitment")]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }

            if (searchString is null)
            {
                searchString = String.Empty;
            }

            var model = _contactService.GetAllContactForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        public IActionResult Send()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Send(Contact model, IFormFile[] attachments)
        {
            try
            {
                FileUploadContactHelper fileUpload = new FileUploadContactHelper(_context, _webHostEnvironment, _configuration);
                int CheckValue = fileUpload.FileH(model, attachments);
                switch (CheckValue)
                {
                    case 1:
                        TempData["success"] = "Sent Mail Successfully";
                        break;
                    case 2:
                        TempData["error"] = "Failed";
                        return RedirectToAction("Send");
                    case 0:
                        TempData["error"] = "You don't selected a file.";
                        return RedirectToAction("Send");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(model.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return View(model);
        }

        // GET: Image/Details/5
        [Authorize(Roles = "Admin, Recruitment")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = _context.Contacts
                .FirstOrDefault(m => m.Id == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }
        [Authorize(Roles = "Admin, Recruitment")]
        public ActionResult GetBlobDownload(int id)
        {
            var imageModel = _context.Contacts.Find(id);
            string file = _hostEnvironment.WebRootPath;
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, @"\Image\", imageModel.ImageName);
            var path = file + imagePath;

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.CopyTo(memory);
            }

            memory.Position = 0;
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return File(memory, GetMimeTypes()[ext], Path.GetFileName(path));
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".csv", "txt/csv"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
            };
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}

