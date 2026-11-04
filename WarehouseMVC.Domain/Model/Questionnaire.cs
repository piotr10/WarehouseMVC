using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace WarehouseMVC.Domain.Model
{
    public class Questionnaire
    {
        public int Id { get; set; }

        //Personal data
        public string Name { get; set; }
        public string Surname { get; set; }
        public Sex Sex { get; set; }
        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Place of birth")]
        public string PlaceOfBirth { get; set; }
        [StringLength(11)]
        public string Pesel { get; set; }
        public string Passport { get; set; }


        [Display(Name = "Identity Card Number")]
        public string IdentityCardNumber { get; set; }
        [Display(Name = "Date of issue")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfIssue { get; set; }
        [Display(Name = "Issuing Authority")]
        public string IssuingAuthority { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        [Display(Name = "Tax office")]
        public string TaxOffice { get; set; } // PL: Urząd skarbowy
        [Display(Name = "Degree of disability")]
        public DegreeOfDisability DegreeOfDisability { get; set; } // PL: Stopień niepełnosprawności
        [Display(Name = "Retiring")]
        public Retirement Retirement { get; set; } // PL: Renta
        [Display(Name = "Address National Health Fund")]
        public string NationalHealthFund { get; set; }

        //Address
        public string Street { get; set; }
        [Display(Name = "House number")]
        public int HouseNumber { get; set; }
        [Display(Name = "Flat number")]
        public int FlatNumber { get; set; }
        public string Town { get; set; }
        public int Postcode { get; set; }
        public string Commune { get; set; } //gmina
        public string District { get; set; } //powiat
        public string Province { get; set; } //województwo
        public string Country { get; set; }

        //The person who  needs to be informed in the event of an accident
        [Display(Name = "Name")]
        public string PersonName { get; set; }
        [Display(Name = "Surname")]
        public string PersonSurname { get; set; }
        [Display(Name = "Address")]
        public string PersonAddress { get; set; }
        [Display(Name = "Phone")]
        public long PersonPhone { get; set; }

        //Bank account
        [Display(Name = "Name of the bank")]
        public string BankName { get; set; }
        [Display(Name = "Bank account number")]
        [StringLength(26)]
        public string AccountNumber { get; set; }
        
        //Other
        public string Subject { get; set; }
        [NotMapped] 
        public string Comment { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Upload Name")]
        public string ImageNameQuestionnaire { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        //Relations with Company One to Many
        [DisplayName("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
public enum Sex
{
    None,
    Male,
    Female
}
public enum DegreeOfDisability
{
    None,
    No,
    Yes
}
public enum Retirement
{
    None,
    No,
    Yes
}