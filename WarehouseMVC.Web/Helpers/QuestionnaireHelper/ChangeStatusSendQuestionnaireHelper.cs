using System.Collections.Generic;
using System.Linq;
using WarehouseMVC.Domain.Model;
using WarehouseMVC.Infrastructure;

namespace WarehouseMVC.Web.Helpers.QuestionnaireHelper
{
    public class ChangeStatusSendQuestionnaireHelper
    {
        private readonly Context _context;

        public ChangeStatusSendQuestionnaireHelper(Context context)
        {
            _context = context;
        }

        public void ChangeStatusQuestionnaire(int id, string status)
        {
            //Change Status from Images when we click Send in Questionnaires
            //Add ImageModel
            List<ImageModel> imageModel = new List<ImageModel>();
            imageModel = (from image in _context.Images
                select image).ToList();
            //Select data to change
            var statusSelect = (from c in imageModel
                where c.Id == id
                select c).First();

            //Set new data
            status = statusSelect.Status = "Send questionnaire";
            //Add Modified to specific data (Status)
            _context.Entry(statusSelect).Property(a => a.Status).IsModified = true;
            _context.SaveChanges();
        }
    }
}