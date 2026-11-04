using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Bogus.DataSets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WarehouseMVC.Domain.Model;
using WarehouseMVC.Infrastructure;
using WarehouseMVC.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using WarehouseMVC.Application.Interfaces;
using WarehouseMVC.Application.ViewModel.Image;
using WarehouseMVC.Web.Helpers;
using WarehouseMVC.Web.Helpers.ImageModelHelper;
using Company = Bogus.DataSets.Company;


namespace WarehouseMVC.Web.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IImageModelService _imageModelService;
        private readonly IQuestionnaireService _questionnaireService;
        private readonly IApplyCountImageModelService _applyCountImageModelService;

        public ImageController(Context context, IWebHostEnvironment webHostEnvironment, IImageModelService imageModelService, IQuestionnaireService questionnaireService, IApplyCountImageModelService applyCountImageModelService)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imageModelService = imageModelService;
            _questionnaireService = questionnaireService;
            _applyCountImageModelService = applyCountImageModelService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Payroll")]
        public IActionResult Index(int pageSize = 10, int page = 1, string searchFilter = "")
        {
            var model = _imageModelService.GetAllImageModelForList(pageSize, page, searchFilter);
            return View(model);
        }

        //[HttpPost]
        [Authorize(Roles = "Admin, Manager, Payroll")]
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

            var model = _imageModelService.GetAllImageModelForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Payroll")]
        public IActionResult Create()
        {
            //Dropdownlist Company
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewData["GroupManagerId"] = new SelectList(_context.GroupManagers, "Id", "Name");
            ViewData["GroupLeaderId"] = new SelectList(_context.GroupLeaders, "Id", "Name");
            
            return View(new NewImageModelVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager, Payroll")]
        public async Task<IActionResult> Create(NewImageModelVm imageModel, int resultApply, int result, IFormFile[] attachments)
        {
            //Dropdownlists
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", imageModel.CompanyId);
            ViewData["GroupManagerId"] = new SelectList(_context.GroupManagers, "Id", "Name", imageModel.GroupManagerId);
            ViewData["GroupLeaderId"] = new SelectList(_context.GroupLeaders, "Id", "Name", imageModel.GroupLeaderId);
            
            //FileUpload
            FileUploadHelper fileUpload = new FileUploadHelper(_context, _webHostEnvironment);
            fileUpload.FileH(imageModel, attachments);

            //Employee application check
            EmployeeApp employeeApp = new EmployeeApp(_context, _applyCountImageModelService);
            List<ApplyCountImageModel> applyCount = new List<ApplyCountImageModel>();
            ApplyCountImageModel ap = new ApplyCountImageModel();
            int employeeCheck = await employeeApp.EmployeeCheckApplication(imageModel, resultApply, result, applyCount, ap);
            
            if (employeeCheck == 1)
            {
                TempData["applyvalfalse"] = "Impossible for employment, please select another application";
                return RedirectToAction("Create");
            }
            else if (employeeCheck == 2)
            {
                TempData["applyvaltrue"] = "Count of the application is OK";
            }
            else if (employeeCheck == 3)
            {
                TempData["applyvaltrue"] = "Save";
            }

            imageModel.AcceptDateTimeRecruitment = "No data";
            imageModel.AcceptDateTimeControlling = "No data";
            imageModel.AcceptDateTimeCfo = "No data";


            //Create new questionnaire
            QuestionnaireAdded questionnaireAdded = new QuestionnaireAdded(_context, _questionnaireService);
            await questionnaireAdded.NewQuestionnaire(imageModel);
            var id = _imageModelService.AddImageModel(imageModel, attachments);
            
            return View();
        }

        [Authorize(Roles = "Admin, Manager, Payroll")]
        public ActionResult GetBlobDownload(int id)
        {
            var imageModel = _context.Images.Find(id);
            if (imageModel.ImageName == "No_Attachment.xyz" || imageModel.ImageName == null)
            {
                TempData["checkvalfalse"] = "No attachment added";
                return RedirectToAction("Edit", new { id = imageModel.Id });
            }
            string file = _webHostEnvironment.WebRootPath;
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"\Image\", imageModel.ImageName);
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

        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Payroll")]
        public IActionResult Edit(int id)
        {
            var imageModel = _imageModelService.GetImageModelForEdit(id);

            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewData["GroupManagerId"] = new SelectList(_context.GroupManagers, "Id", "Name");
            ViewData["GroupLeaderId"] = new SelectList(_context.GroupLeaders, "Id", "Name");

            return View(imageModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]         // Next Step is Edit this Action !!!!!
        [Authorize(Roles = "Admin, Payroll")]
        public IActionResult Edit(int id, int result, int resultApply, NewImageModelVm imageModel, IFormFile[] attachments)
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", imageModel.CompanyId);
            ViewData["GroupManagerId"] = new SelectList(_context.GroupManagers, "Id", "Name", imageModel.GroupManagerId);
            ViewData["GroupLeaderId"] = new SelectList(_context.GroupLeaders, "Id", "Name", imageModel.GroupLeaderId);

            if (id != imageModel.Id)
            {
                return NotFound();
            }

            //FileUpload
            if (attachments != null && attachments.Length > 0)
            {
                EditFileUploadHelper fileUpload = new EditFileUploadHelper(_context, _webHostEnvironment);
                fileUpload.EditFileH(imageModel, attachments);
                TempData["checkvaltrue"] = "Attachment added";
            }

            //Check accept payroll and addhoc / rotation / harmonogram hired
            if (ModelState.IsValid)
            {
                try
                {
                    EditCheckValueAccept checkValue = new EditCheckValueAccept(_context);

                    int CheckValueAccept = checkValue.CheckAccept(imageModel);
                    switch (CheckValueAccept)
                    {
                        case 1:
                            TempData["checkvaltrue"] = "Employee hired";
                            break;
                        case 2:
                            TempData["checkvalfalse"] = "You don't have enough Accept";
                            return RedirectToAction("Edit");
                        case 3:
                            imageModel.FinallyHiredPayroll = false;
                            TempData["checkvalfalse"] = "Denied";
                            break;
                        case 4:
                            TempData["checkvalfalse"] = "You don't have enough Denied";
                            return RedirectToAction("Edit");
                    }
                    
                    if (imageModel.Rotation == true && imageModel.FinallyHiredPayroll == true)
                    {
                        TempData["checkvaltrue"] = "Employee hired";
                    }
                    else if (imageModel.Rotation == true && imageModel.FinallyHiredPayrollFalse == true)
                    {
                        TempData["checkvalfalse"] = "Denied";
                    }
                    //Finall accept CompatibleHarmonogram 
                    if (imageModel.CompatibleHarmonogram == true && imageModel.FinallyHiredPayroll == true)
                    {
                        TempData["checkvaltrue"] = "Employee hired";
                    }
                    //Finall denied CompatibleHarmonogram 
                    else if (imageModel.CompatibleHarmonogram == true && imageModel.FinallyHiredPayrollFalse == true)
                    {
                        TempData["checkvalfalse"] = "Denied";
                    }

                    checkValue.CheckData(imageModel);
                    _imageModelService.UpdateImageModel(imageModel);
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageModelExists(imageModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(imageModel);
        }

        // GET: Image/Delete/5
        [Authorize(Roles = "Admin, Payroll")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = _context.Images
                .FirstOrDefault(m => m.Id == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Payroll")]
        public IActionResult DeleteConfirmed(int id)
        {
            var imageModel = _context.Images.Find(id);

            //delete image from wwwroot/image
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Image", imageModel.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                Thread.Sleep(0);
                System.IO.File.Delete(imagePath);
            }

            //delete the record
            _context.Images.Remove(imageModel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Image/Details/5
        [Authorize(Roles = "Admin, Manager, Payroll")]
        public IActionResult Details(int? id, ImageModelDetailsVm detailsVm)
        {
            ViewData["GroupManagerId"] = new SelectList(_context.GroupManagers, "Id", "Name", detailsVm.GroupManagerId);
            ViewData["GroupLeaderId"] = new SelectList(_context.GroupLeaders, "Id", "Name", detailsVm.GroupLeaderId);
            if (id == null)
            {
                return NotFound();
            }

            var imageModelDetails = _imageModelService.GetImageModelDetails(id);
            if (imageModelDetails == null)
            {
                return NotFound();
            }

            return View(imageModelDetails);
        }

        private bool ImageModelExists(int id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}

/*TODO:
 * 1.Add Action in Questionnaire Edit Actopm - when the tandidate click Save then the status change to "kwestionariusz uzupełniony"
 * 2.Add button "Wysłanei skierowanie na badania lekarskie"
 * 3.Nawe of applications e.g. "WZZ + data zatrudnienia + ... "
 * 4.Optional: "Pasek statusu toggl"
 * 5.Add Added New job title (nazwa stanowiska)
 */