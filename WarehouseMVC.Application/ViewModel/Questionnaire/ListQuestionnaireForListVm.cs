using System.Collections.Generic;

namespace WarehouseMVC.Application.ViewModel.Questionnaire
{
    public class ListQuestionnaireForListVm
    {
        public List<QuestionnaireForListVm> Questionnaires { get; set; }

        // For pagination
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}