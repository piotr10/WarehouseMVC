using System.Linq;
using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Infrastructure.Repositories
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private readonly Context _context;
        public QuestionnaireRepository(Context context)
        {
            _context = context;
        }

        public int AddQuestionnaire(Questionnaire questionnaire)
        {
            _context.Questionnaires.AddAsync(questionnaire);
            _context.SaveChangesAsync();
            return questionnaire.Id;
        }

        public void SendQuestionnaire(Questionnaire questionnaire)
        {
            _context.Attach(questionnaire);
            _context.SaveChanges();
        }

        public void DeleteQuestionnaire(int id)
        {
            var questionnaire = _context.Questionnaires.Find(id);
            if (questionnaire != null)
            {
                _context.Questionnaires.Remove(questionnaire);
                _context.SaveChanges();
            }
        }

        public IQueryable<Questionnaire> GetAllQuestionnaire()
        {
            //var questionnaire = _context.Questionnaire.Where(p => p.IsActive);
            var questionnaire = _context.Questionnaires;
            return questionnaire;
        }

        public Questionnaire GetQuestionnaire(int questionnaireId)
        {
            return _context.Questionnaires.FirstOrDefault(p => p.Id == questionnaireId);
        }

        public void UpdateQuestionnaire(Questionnaire questionnaire)
        {
            _context.Attach(questionnaire);
            _context.Entry(questionnaire).Property("Id").IsModified = false;

            #region IsModified = true
            _context.Entry(questionnaire).Property("Name").IsModified = true;
            _context.Entry(questionnaire).Property("Surname").IsModified = true;
            _context.Entry(questionnaire).Property("Sex").IsModified = true;
            _context.Entry(questionnaire).Property("DateOfBirth").IsModified = true;
            _context.Entry(questionnaire).Property("PlaceOfBirth").IsModified = true;
            _context.Entry(questionnaire).Property("Pesel").IsModified = true;
            _context.Entry(questionnaire).Property("Passport").IsModified = true;
            _context.Entry(questionnaire).Property("IdentityCardNumber").IsModified = true;
            _context.Entry(questionnaire).Property("DateOfIssue").IsModified = true;
            _context.Entry(questionnaire).Property("IssuingAuthority").IsModified = true;
            _context.Entry(questionnaire).Property("Phone").IsModified = true;
            _context.Entry(questionnaire).Property("Email").IsModified = true;
            _context.Entry(questionnaire).Property("Nationality").IsModified = true;
            _context.Entry(questionnaire).Property("TaxOffice").IsModified = true;
            _context.Entry(questionnaire).Property("DegreeOfDisability").IsModified = true;
            _context.Entry(questionnaire).Property("Retirement").IsModified = true;
            _context.Entry(questionnaire).Property("NationalHealthFund").IsModified = true;
            _context.Entry(questionnaire).Property("Street").IsModified = true;
            _context.Entry(questionnaire).Property("HouseNumber").IsModified = true;
            _context.Entry(questionnaire).Property("FlatNumber").IsModified = true;
            _context.Entry(questionnaire).Property("Town").IsModified = true;
            _context.Entry(questionnaire).Property("Postcode").IsModified = true;
            _context.Entry(questionnaire).Property("Commune").IsModified = true;
            _context.Entry(questionnaire).Property("District").IsModified = true;
            _context.Entry(questionnaire).Property("Province").IsModified = true;
            _context.Entry(questionnaire).Property("Country").IsModified = true;
            _context.Entry(questionnaire).Property("PersonName").IsModified = true;
            _context.Entry(questionnaire).Property("PersonSurname").IsModified = true;
            _context.Entry(questionnaire).Property("PersonAddress").IsModified = true;
            _context.Entry(questionnaire).Property("PersonPhone").IsModified = true;
            _context.Entry(questionnaire).Property("BankName").IsModified = true;
            _context.Entry(questionnaire).Property("AccountNumber").IsModified = true;
            _context.Entry(questionnaire).Property("Subject").IsModified = true;
            _context.Entry(questionnaire).Property("CompanyId").IsModified = true;
            #endregion

            //_context.Entry(questionnaire).Property("Status").IsModified = true;      // ????????????? is there Status in Model?
            _context.SaveChanges();
        }

        public IQueryable<Company> GetQuestionnaireByCompanyId(int companyId)
        {
            var company = _context.Companies.Where(i => i.Id == companyId);
            return company;
        }

        public IQueryable<Company> GetAllCompany()
        {
            var company = _context.Companies;
            return company;
        }
    }
}