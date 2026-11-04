using Microsoft.AspNetCore.Http;
using WarehouseMVC.Application.ViewModel.Questionnaire;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application.Interfaces
{
    public interface IQuestionnaireService
    {
        ListQuestionnaireForListVm GetAllQuestionnaireForList(int pageSize, int pageNo, string searchString);
        int AddQuestionnaire(Questionnaire questionnaire);
        void SendQuestionnaire(NewSendQuestionnaireVm questionnaire, int id, string status, IFormFile[] attachments);
        QuestionnaireDetailsVm GetQuestionnaireDetails(int id);
        void DeleteQuestionnaire(int id);
        NewQuestionnaireVm GetQuestionnaireForEdit(int id);
        NewSendQuestionnaireVm SendQuestionnaireVm(int id);
        void UpdateQuestionnaire(NewQuestionnaireVm model);
    }
}