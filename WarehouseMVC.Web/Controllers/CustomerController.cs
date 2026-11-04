using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WarehouseMVC.Application.Interfaces;
using WarehouseMVC.Application.ViewModel.Customer;
using WarehouseMVC.Web.Filters;
using System.Dynamic;

namespace WarehouseMVC.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _custService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService custService, ILogger<CustomerController> logger)
        {
            _custService = custService;
            _logger = logger;
        }
        
        //[Authorize(Policy = "CanViewCustomers")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _custService.GetAllCustomerForList(2, 1, "");
            return View(model);
        }
        
        //[Authorize(Policy = "CanViewCustomers")]
        //[HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            _logger.LogInformation("Jestem w Customer/Index");
            
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            
            var model = _custService.GetAllCustomerForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        //ta akcja zwraca widok customera / czyli widok z formularzem do dodawania nowego klienta
        //[Authorize(Policy = "CanAddNewCustomer")]
        //[Authorize(Policy = "CanViewCustomers")]
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View(new NewCustomerVm());
        }

        //po wypełnieniu formularza zwrócę z formularza odpowiedni model CustomerModel model,
        //który zostanie dalej przekazany do serwisu w celu przekazania przez serwis tego modelu do repozytorium i stworzył nowego klienta 
        //i tak będziemy dodawać wszystkie akcje związane z klientami - jedna będzie z HtttpGet a druga z HttpPosts
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCustomer(NewCustomerVm model)
        {
            var id = _custService.AddCustomer(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            var customer = _custService.GetCustomerForEdit(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult EditCustomer(NewCustomerVm model)
        {
            _custService.UpdateCustomer(model);
            return RedirectToAction("Index");
        }

        //Formularz do dodawania nowego adresu dla odpowiedniego klienta - customerId
        [HttpGet]
        public IActionResult AddNewAdressForClient(int customerId)
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddNewAdressForClient(AdressModel model)
        //{
        //    return View();
        //}

        //pobieramy z serwisu informacje o moim kliencie i przekazujemy do widoku 
        public IActionResult ViewCustomer(int customerId)
        {
            var customerModel = _custService.GetCustomerDetails(customerId);
            return View(customerModel);
        }
        public IActionResult Delete(int id)
        {
            _custService.DeleteCustomer(id);
            return RedirectToAction("Index");
        }

        /* // Wyswietlanie wgranego pliku z konkretnej ścieżki
        [HttpPost]
        public IActionResult ViewDocument()
        {
            string fileName = Request.Form["fileToView"];
            string outputDirectory = ("Output/");
            string outputFilePath = Path.Combine(outputDirectory, "output.pdf");
            using (Viewer viewer = new Viewer(@"C:\Users\User\Desktop\Dokumenty do kredytu\Dokumenty\" + fileName))
            {
                PdfViewOptions options = new PdfViewOptions(outputFilePath);
                viewer.View(options);
            }
            var fileStream = new FileStream("Output/" + "output.pdf",
                FileMode.Open,
                FileAccess.ReadWrite
                );
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            return fsResult;
        }
        */
    }

}
