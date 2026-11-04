using AutoMapper;
using WarehouseMVC.Application.Mapping;


namespace WarehouseMVC.Application.ViewModel.Customer
{
    public class CustomerForListVm : IMapFrom<WarehouseMVC.Domain.Model.Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<WarehouseMVC.Domain.Model.Customer, CustomerForListVm>();
            /*
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.NIP, opt => opt.MapFrom(s => s.NIP));
            */
        }
    }
}