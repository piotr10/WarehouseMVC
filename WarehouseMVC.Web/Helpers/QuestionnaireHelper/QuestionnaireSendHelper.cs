using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WarehouseMVC.Application.ViewModel.Questionnaire;
using WarehouseMVC.Infrastructure;
using WarehouseMVC.Web.Helpers.ImageModelHelper;

namespace WarehouseMVC.Web.Helpers.QuestionnaireHelper
{
    public class QuestionnaireSendHelper
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;

        public QuestionnaireSendHelper(Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public bool Send(NewSendQuestionnaireVm questionnaire, int id, IFormFile[] attachments)
        {
            List<string> fileNames = null;
            fileNames = new List<string>();
            foreach (IFormFile attachment in attachments)
            {
                string fileName = Path.GetFileName(attachment.FileName);

                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    attachment.CopyTo(stream);
                }

                fileNames.Add(fileName);
            }

            var body = "Hello," +
                       "<br> Please complete the questionnaire using the link below:" +
                       "<br> " + _configuration["App:BaseUrl"] + "/Questionnaire/Edit/" + id +
                       "<br> Any required documents are attached to this message." +
                       "<br> If you have any questions, feel free to reply to this e-mail. <br>" +
                       "<br> Best regards," +
                       "<br>" + questionnaire.Comment +
                       "<br> hr-team@example.com" + "<br>";

            var mailHelper = new MailHelpersOutlook(_configuration);

            if (mailHelper.Send(_configuration["Outlook:Username"], questionnaire.Email, questionnaire.Subject, body, fileNames))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}