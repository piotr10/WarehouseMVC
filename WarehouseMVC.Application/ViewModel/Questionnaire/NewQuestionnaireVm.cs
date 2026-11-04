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
    public class NewQuestionnaireVm : IMapFrom<WarehouseMVC.Domain.Model.Questionnaire>
    {
        public int Id { get; set; }

        //Personal data
        public string Name { get; set; }
        public string Surname { get; set; }
        public Sex Sex { get; set; }
        [DisplayName("Date of birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateOfBirth { get; set; }
        [DisplayName("Place of birth")]
        public string PlaceOfBirth { get; set; }
        [StringLength(11)]
        public string Pesel { get; set; }
        public string Passport { get; set; }

        [DisplayName("Identity Card Number")]
        [RegularExpression(@"^\(?([A-Z]{3})\)?[-. ]?([0-9]{6})[-. ]$", ErrorMessage = "Not a valid Identity Card Number (e.g. AAA111111).")]
        public string IdentityCardNumber { get; set; }
        [DisplayName("Date of issue")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateOfIssue { get; set; }
        [DisplayName("Issuing Authority")]
        public string IssuingAuthority { get; set; }

        [DisplayName("Phone number")]
        public long Phone { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        [DisplayName("Tax office")]
        public string TaxOffice { get; set; } // PL: Urząd skarbowy
        [DisplayName("Degree of disability")]
        public DegreeOfDisability DegreeOfDisability { get; set; } // PL: Stopień niepełnosprawności
        [DisplayName("Retiring")]
        public Retirement Retirement { get; set; } // PL: Renta
        [DisplayName("Address National Health Fund")]
        public string NationalHealthFund { get; set; }

        //Address
        public string Street { get; set; }
        [DisplayName("House number")]
        public int HouseNumber { get; set; }
        [DisplayName("Flat number")]
        public int FlatNumber { get; set; }
        public string Town { get; set; }
        public int Postcode { get; set; }
        public string Commune { get; set; } //gmina
        public string District { get; set; } //powiat
        public string Province { get; set; } //województwo
        public string Country { get; set; }

        //The person who  needs to be informed in the event of an accident
        [DisplayName("Name")]
        public string PersonName { get; set; }
        [DisplayName("Surname")]
        public string PersonSurname { get; set; }
        [DisplayName("Address")]
        public string PersonAddress { get; set; }
        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Not a valid phone number. Please enter 9 numbers your telephone.")]
        public long PersonPhone { get; set; }

        //Bank account
        [DisplayName("Name of the bank")]
        public string BankName { get; set; }
        [DisplayName("Bank account number")]
        [RegularExpression(@"^\(?([0-9]{26})\)$", ErrorMessage = "Not a valid bank account number. Please enter 26 numbers.")]
        [StringLength(26)]
        public string AccountNumber { get; set; }

        //Other
        public string Subject { get; set; }
        public string Comment { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Upload Name")]
        public string ImageNameQuestionnaire { get; set; }
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        //Relations with Company One to Many
        [DisplayName("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewQuestionnaireVm, WarehouseMVC.Domain.Model.Questionnaire>().ReverseMap();
        }
    }
}