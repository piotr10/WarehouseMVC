using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using WarehouseMVC.Application.Mapping;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application.ViewModel.Image
{
    public class ImageForListVm : IMapFrom<WarehouseMVC.Domain.Model.ImageModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Employment date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? EmploymentDate { get; set; }
        [DisplayName("Establishment plan")]
        public bool CompatibleHarmonogram { get; set; }
        [DisplayName("Add Hoc")]
        public bool AddHoc { get; set; }
        public bool Rotation { get; set; }
        [DisplayName("Managment accept")]
        public string IsHired { get; set; }
        [DisplayName("Payroll accept")]
        public bool FinallyHiredPayroll { get; set; }
        public string Status { get; set; }
        [DisplayName("Recruitment")]
        public AcceptHiredRecruitment AcceptHiredRecruitment { get; set; }
        [DisplayName("Controlling")]
        public AcceptHiredControlling AcceptHiredControlling { get; set; }
        [DisplayName("CFO")]
        public AcceptHiredCfo AcceptHiredCfo { get; set; }
        public bool FinallyHiredPayrollFalse { get; set; }

        [DisplayName("Manager group")]
        public int GroupManagerId { get; set; }
        public virtual GroupManager GroupManager { get; set; }

        [DisplayName("Leader group")]
        public int GroupLeaderId { get; set; }
        public virtual GroupLeader GroupLeader { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<WarehouseMVC.Domain.Model.ImageModel, ImageForListVm>();
        }
    }
}