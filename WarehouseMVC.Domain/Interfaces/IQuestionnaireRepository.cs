using System.Linq;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Domain.Interfaces
{
    public interface IQuestionnaireRepository
    {
        IQueryable<Questionnaire> GetAllQuestionnaire();
        Questionnaire GetQuestionnaire(int questionnaireId);
        int AddQuestionnaire(Questionnaire questionnaire);
        void SendQuestionnaire(Questionnaire questionnaire);
        void UpdateQuestionnaire(Questionnaire questionnaire);
        void DeleteQuestionnaire(int id);
        IQueryable<Company> GetQuestionnaireByCompanyId(int companyId);
        IQueryable<Company> GetAllCompany();
    }
}