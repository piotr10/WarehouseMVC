using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using WarehouseMVC.Application.Mapping;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application.ViewModel.Image
{
    public class ImageModelDetailsVm : IMapFrom<WarehouseMVC.Domain.Model.ImageModel>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }

        [DisplayName("Manager group")]
        public int GroupManagerId { get; set; }
        public virtual GroupManager GroupManager { get; set; }

        [DisplayName("Leader group")]
        public int GroupLeaderId { get; set; }
        public virtual GroupLeader GroupLeader { get; set; }

        [DisplayName("Surname and Name")]
        public string FullName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<WarehouseMVC.Domain.Model.ImageModel, ImageModelDetailsVm>()
                .ForMember(s => s.FullName, opt => opt.MapFrom(d => d.Surname + " " + d.Name));
        }
    }
}