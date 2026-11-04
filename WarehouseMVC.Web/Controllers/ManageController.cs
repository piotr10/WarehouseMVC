using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseMVC.Domain.Model;
using WarehouseMVC.Infrastructure;
using WarehouseMVC.Web.Models;

namespace WarehouseMVC.Web.Controllers
{
    [Authorize(Roles = "Admin, Controlling")]
    public class ManageController : Controller
    {
        private readonly Context _context;

        public ManageController(Context context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;

        }

        public IActionResult Index(int pageNumber = 1)
        {
            var result = _context.ApplyCountImageModels.OrderByDescending(a => a.Id);

            return View(PaginatedList<ApplyCountImageModel>.Create(result, pageNumber, 1));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apply = _context.ApplyCountImageModels.Find(id);
            if (apply == null)
            {
                return NotFound();
            }
            return View(apply);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ApplyCountImageModel apply)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apply);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplyModelExists(apply.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        private bool ApplyModelExists(int id)
        {
            return _context.ApplyCountImageModels.Any(e => e.Id == id);
        }
    }
}
