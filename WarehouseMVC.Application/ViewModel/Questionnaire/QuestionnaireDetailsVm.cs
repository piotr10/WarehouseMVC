using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using WarehouseMVC.Application.Mapping;

namespace WarehouseMVC.Application.ViewModel.Questionnaire
{
    public class QuestionnaireDetailsVm : IMapFrom<WarehouseMVC.Domain.Model.Questionnaire>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [DisplayName("Phone number")]
        public long Phone { get; set; }
        public string Street { get; set; }
        [DisplayName("House number")]
        public int HouseNumber { get; set; }
        [DisplayName("Flat number")]
        public int FlatNumber { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        [DisplayName("Surname and Name")]
        public string FullName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<WarehouseMVC.Domain.Model.Questionnaire, QuestionnaireDetailsVm>()
                .ForMember(s => s.FullName, opt => opt.MapFrom(d => d.Surname + " " + d.Name));
        }
    }
}