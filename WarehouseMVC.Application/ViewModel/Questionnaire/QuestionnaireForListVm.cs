using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using WarehouseMVC.Application.Mapping;

namespace WarehouseMVC.Application.ViewModel.Questionnaire
{
    public class QuestionnaireForListVm : IMapFrom<WarehouseMVC.Domain.Model.Questionnaire>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid email.")]
        public string Email { get; set; }
        [DisplayName("Phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Not a valid phone number. Please enter 9 numbers your telephone.")]
        public long Phone { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<WarehouseMVC.Domain.Model.Questionnaire, QuestionnaireForListVm>();
        }
    }
}