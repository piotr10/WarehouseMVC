using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using WarehouseMVC.Application.Interfaces;
using WarehouseMVC.Application.ViewModel.Questionnaire;
using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IQuestionnaireRepository _questionnaireRepo;
        private readonly IMapper _mapper;

        public QuestionnaireService(IQuestionnaireRepository questionnaireRepo, IMapper mapper)
        {
            _questionnaireRepo = questionnaireRepo;
            _mapper = mapper;
        }
        
        public int AddQuestionnaire(Questionnaire questionnaire)
        {
            var quest = _mapper.Map<Questionnaire>(questionnaire);
            var id = _questionnaireRepo.AddQuestionnaire(quest);
            return id;
        }
        public void SendQuestionnaire(NewSendQuestionnaireVm questionnaire, int id, string status, IFormFile[] attachments)
        {
            var quest = _mapper.Map<Questionnaire>(questionnaire);
            _questionnaireRepo.SendQuestionnaire(quest);
        }

        public ListQuestionnaireForListVm GetAllQuestionnaireForList(int pageSize, int pageNo, string searchString)
        {
            var questionnaire = _questionnaireRepo.GetAllQuestionnaire().Where(p => p.Name.StartsWith(searchString) | p.Surname.StartsWith(searchString))
                .ProjectTo<QuestionnaireForListVm>(_mapper.ConfigurationProvider).ToList();

            var questionnaireToShow = questionnaire.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var questionnaireList = new ListQuestionnaireForListVm()
            {
                Questionnaires = questionnaireToShow,
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Count = questionnaire.Count
            };

            return questionnaireList;
        }

        public QuestionnaireDetailsVm GetQuestionnaireDetails(int id)
        {
            var questionnaire = _questionnaireRepo.GetQuestionnaire(id);
            var questionnaireVm = _mapper.Map<QuestionnaireDetailsVm>(questionnaire);

            return questionnaireVm;
        }

        public void DeleteQuestionnaire(int id)
        {
            throw new System.NotImplementedException();
        }

        public NewQuestionnaireVm GetQuestionnaireForEdit(int id)
        {
            var questionnaire = _questionnaireRepo.GetQuestionnaire(id);
            var questionnaireVm = _mapper.Map<NewQuestionnaireVm>(questionnaire);

            return questionnaireVm;
        }

        public NewSendQuestionnaireVm SendQuestionnaireVm(int id)
        {
            var questionnaire = _questionnaireRepo.GetQuestionnaire(id);
            var questionnaireVm = _mapper.Map<NewSendQuestionnaireVm>(questionnaire);

            return questionnaireVm;
        }

        public void UpdateQuestionnaire(NewQuestionnaireVm model)
        {
            var imageModel = _mapper.Map<Questionnaire>(model);
            _questionnaireRepo.UpdateQuestionnaire(imageModel);
        }
    }
}