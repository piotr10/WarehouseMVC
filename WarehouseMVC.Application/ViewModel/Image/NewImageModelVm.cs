using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using WarehouseMVC.Application.Mapping;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application.ViewModel.Image
{
    public class NewImageModelVm : IMapFrom<WarehouseMVC.Domain.Model.ImageModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        [DisplayName("Phone number")]
        public long Phone { get; set; }
        [DisplayName("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        [DisplayName("Manager group")]
        public int GroupManagerId { get; set; }
        public virtual GroupManager GroupManager { get; set; }
        [DisplayName("Leader group")]
        public int GroupLeaderId { get; set; }
        public virtual GroupLeader GroupLeader { get; set; }
        public double Price { get; set; }
        [DisplayName("Added From")]
        public string AddFrom { get; set; }
        [DisplayName("Recruitment")]
        public AcceptHiredRecruitment AcceptHiredRecruitment { get; set; }
        [DisplayName("Controlling")]
        public AcceptHiredControlling AcceptHiredControlling { get; set; }
        [DisplayName("CFO")]
        public AcceptHiredCfo AcceptHiredCfo { get; set; }
        [DisplayName("Form of employment")]
        public EmployedUnder EmployedUnder { get; set; }
        [Display(Name = "Employment date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? EmploymentDate { get; set; }
        [DisplayName("Establishment plan")]
        public bool CompatibleHarmonogram { get; set; }
        [DisplayName("Add Hoc")]
        public bool AddHoc { get; set; }
        public bool Rotation { get; set; }
        [DisplayName("Upload Name")]
        public string ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
        public string Status { get; set; }
        [DisplayName("Managment accept")]
        public string IsHired { get; set; }
        [DisplayName("Payroll accept")]
        public bool FinallyHiredPayroll { get; set; }
        public bool FinallyHiredPayrollFalse { get; set; }
        public string ReasonDenied { get; set; }
        public string AcceptDateTimeRecruitment { get; set; }
        public string AcceptDateTimeControlling { get; set; }
        public string AcceptDateTimeCfo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewImageModelVm, WarehouseMVC.Domain.Model.ImageModel>().ReverseMap();
        }
    }
}