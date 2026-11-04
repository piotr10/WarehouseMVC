using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using WarehouseMVC.Application.Mapping;

namespace WarehouseMVC.Application.ViewModel.Contact
{
    public class ContactForListVm : IMapFrom<WarehouseMVC.Domain.Model.Contact>
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        [DisplayName("Added From")]
        public string AddFrom { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
        public long Phone { get; set; }
        public string Subject { get; set; }
        public string Surname { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Upload Name")]
        [Required]
        public string ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<WarehouseMVC.Domain.Model.Contact, ContactForListVm>();
        }
    }
}