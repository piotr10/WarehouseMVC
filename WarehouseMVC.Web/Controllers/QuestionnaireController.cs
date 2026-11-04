using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using WarehouseMVC.Application.Interfaces;
using WarehouseMVC.Application.ViewModel.Questionnaire;
using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Domain.Model;
using WarehouseMVC.Infrastructure;
using WarehouseMVC.Web.Helpers;
using WarehouseMVC.Web.Helpers.ImageModelHelper;
using WarehouseMVC.Web.Helpers.QuestionnaireHelper;

namespace WarehouseMVC.Web.Controllers
{
    [Authorize(Roles = "Admin, Payroll")]
    public class QuestionnaireController : Controller
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IQuestionnaireService _questionnaireService;

        public QuestionnaireController(IConfiguration configuration, IWebHostEnvironment webHostEnvironment, IQuestionnaireService questionnaireService, Context context)
        {
            _context = context;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _questionnaireService = questionnaireService;
        }

        [HttpGet]
        public IActionResult Index(int pageSize = 10, int page = 1, string searchFilter = "")
        {
            var model = _questionnaireService.GetAllQuestionnaireForList(pageSize, page, searchFilter);
            return View(model);
        }

        [HttpPost]
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

            var model = _questionnaireService.GetAllQuestionnaireForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        // GET: QuestionnaireController/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            return View();
        }

        // POST: QuestionnaireController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Questionnaire questionnaire)
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", questionnaire.CompanyId);
            //var id = _questionnaireService.AddQuestionnaire(questionnaire);
            return View(questionnaire);
        }

        [HttpGet]
        public IActionResult Send(int id)
        {
            var questionnaire = _questionnaireService.SendQuestionnaireVm(id);
            return View(questionnaire);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Send(NewSendQuestionnaireVm questionnaire, int id, string status, IFormFile[] attachments)
        {

            if (attachments != null && attachments.Length > 0)
            {
                QuestionnaireSendHelper sendHelper = new QuestionnaireSendHelper(_context, _configuration);
                bool sendHelperValue = sendHelper.Send(questionnaire, id, attachments);

                if (sendHelperValue == true)
                {
                    TempData["success"] = "Sent Mail Successfully";
                }
                else
                {
                    TempData["error"] = "Failed";
                }

                ChangeStatusSendQuestionnaireHelper statusSendQuestionnaire = new ChangeStatusSendQuestionnaireHelper(_context);
                statusSendQuestionnaire.ChangeStatusQuestionnaire(id, status);

                _questionnaireService.SendQuestionnaire(questionnaire, id, status, attachments);
            }

            else
            {
                TempData["error"] = "You don't selected a file.";
                return RedirectToAction("Send");
            }
            
            return View();
        }
        #region Edit

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var questionnaire = _questionnaireService.GetQuestionnaireForEdit(id);

            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            return View(questionnaire);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection, NewQuestionnaireVm questionnaire)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", questionnaire.CompanyId);

                    _questionnaireService.UpdateQuestionnaire(questionnaire);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionnaireModelExists(questionnaire.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(questionnaire);
        }
        #endregion

        #region Delete

        // GET: QuestionnaireController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuestionnaireController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Details
        // GET: QuestionnaireController/Details/5
        public IActionResult Details(int id)
        {
            var questionnaireDetails = _questionnaireService.GetQuestionnaireDetails(id);
            if (questionnaireDetails == null)
            {
                return NotFound();
            }

 
            return View(questionnaireDetails);
        }
        #endregion

        private bool QuestionnaireModelExists(int id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}
