using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WarehouseMVC.Domain.Model
{
    public class ImageModel : IEnumerable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }

        [DisplayName("Added From")]
        public string AddFrom { get; set; }
        public string Subject { get; set; }
        [DisplayName("Managment accept")]
        public string IsHired { get; set; }
        [DisplayName("Recruitment")]
        public AcceptHiredRecruitment AcceptHiredRecruitment { get; set; }
        [DisplayName("Controlling")]
        public AcceptHiredControlling AcceptHiredControlling { get; set; }
        [DisplayName("CFO")]
        public AcceptHiredCfo AcceptHiredCfo { get; set; } //Dyrektor finansowy ang. Chief Financial Officer
        [Display(Name = "Employment date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EmploymentDate { get; set; }
        [DisplayName("Form of employment")]
        public EmployedUnder EmployedUnder { get; set; }
        [DisplayName("Payroll accept")]
        public bool FinallyHiredPayroll { get; set; }
        public bool FinallyHiredPayrollFalse { get; set; }
        public string ReasonDenied { get; set; }

        [DisplayName("Upload Name")]
        public string ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
        public double Price { get; set; }
        [DisplayName("Establishment plan")]
        public bool CompatibleHarmonogram { get; set; }
        [DisplayName("Add Hoc")]
        public bool AddHoc { get; set; }
        public bool Rotation { get; set; }     
        public string Status { get; set; }
        [NotMapped]
        public bool IsActive { get; set; }

        //Relations with Company One to Many
        [DisplayName("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        //Relations with GroupManager One to Many
        [DisplayName("Manager group")]
        public int GroupManagerId { get; set; }
        public virtual GroupManager GroupManager { get; set; }

        //Relations with GroupLeader One to Many
        [DisplayName("Leader group")]
        public int GroupLeaderId { get; set; }
        public virtual GroupLeader GroupLeader { get; set; }

        public string AcceptDateTimeRecruitment { get; set; }
        public string AcceptDateTimeControlling { get; set; }
        public string AcceptDateTimeCfo { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    public enum AcceptHiredRecruitment
    {
        None,
        Accept,
        Denied
    }
    public enum AcceptHiredControlling
    {
        None,
        Accept,
        Denied
    }
    public enum AcceptHiredCfo
    {
        None,
        Accept,
        Denied
    }
    public enum EmployedUnder
    {
        None,
        DG,
        UoP,
        UC
    }
    //business activity - działaność gospodarcza
}