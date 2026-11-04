using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarehouseMVC.Application.Interfaces;
using WarehouseMVC.Application.ViewModel.Image;
using WarehouseMVC.Domain.Model;
using WarehouseMVC.Infrastructure;

namespace WarehouseMVC.Web.Helpers.ImageModelHelper
{
    public class QuestionnaireAdded
    {
        private readonly Context _context;
        private readonly IQuestionnaireService _questionnaireService;

        public QuestionnaireAdded(Context context, IQuestionnaireService questionnaireService)
        {
            _context = context;
            _questionnaireService = questionnaireService;
        }

        public async Task NewQuestionnaire(NewImageModelVm imageModel)
        {
            var quest = new Questionnaire
            {
                Name = imageModel.Name,
                Surname = imageModel.Surname,
                Email = imageModel.Email,
                Phone = imageModel.Phone,
                CompanyId = imageModel.CompanyId
            };

            //_context.Entry(quest).State = EntityState.Added;
            //await _context.AddAsync(new Questionnaire() { Name = imageModel.Name, Surname = imageModel.Surname, Email = imageModel.Email, Phone = imageModel.Phone, CompanyId = imageModel.CompanyId });
            
            var id = _questionnaireService.AddQuestionnaire(quest);

            //Insert record
            imageModel.AddFrom = "Added from application";
            imageModel.IsHired = "Default";
            imageModel.Status = "New applications!";
            //_context.SaveChangesAsync();
        }
    }
}