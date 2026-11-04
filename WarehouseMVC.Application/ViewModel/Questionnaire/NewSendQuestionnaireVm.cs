using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using WarehouseMVC.Application.Mapping;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application.ViewModel.Questionnaire
{
    public class NewSendQuestionnaireVm : IMapFrom<WarehouseMVC.Domain.Model.Questionnaire>
    {
        public int Id { get; set; }

        //Personal data
        public string Name { get; set; }
        public string Surname { get; set; }

        [DisplayName("Phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Not a valid phone number. Please enter 9 numbers your telephone.")]
        public long Phone { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid email.")]
        public string Email { get; set; }

        //Address
        public string Street { get; set; }
        public string Country { get; set; }

        //Other
        public string Subject { get; set; }
        public string Comment { get; set; }
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        //Relations with Company One to Many
        [DisplayName("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        //Mapping
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewSendQuestionnaireVm, WarehouseMVC.Domain.Model.Questionnaire>().ReverseMap();
        }
    }
}