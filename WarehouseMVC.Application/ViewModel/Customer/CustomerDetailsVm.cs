using System.Collections.Generic;
using AutoMapper;
using WarehouseMVC.Application.Mapping;

namespace WarehouseMVC.Application.ViewModel.Customer
{
    public class CustomerDetailsVm : IMapFrom<WarehouseMVC.Domain.Model.Customer> // Model, który wykorzystam w akcji ViewCustomer() w kontrolerze
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
        public string CEOFullName { get; set; } //zamiast pobierać imię i oddzielnie nazwisko to pobieramy łącznie imię nazwisko, które bedą łączone na etapie serwisu
        public string FirstLineOfContactInformation { get; set; } //informacje o kontakcie do danej firmy / klienta i tu też jak w CEOFullName imie i nazwisko połączymy na etapie serwisu
        public List<AddressForListVm> Addresses { get; set; }
        public List<ContactDetailListVm> Emails { get; set; }
        public List<ContactDetailListVm> PhoneNumbers { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<WarehouseMVC.Domain.Model.Customer, CustomerDetailsVm>()
                .ForMember(s => s.CEOFullName, opt => opt.MapFrom(d => d.CEOName + " " + d.CEOLastName))
                .ForMember(s => s.FirstLineOfContactInformation, opt =>
                opt.MapFrom(d => d.CustomerContactInformation.FirstName 
                + " " + d.CustomerContactInformation.LastName))
                .ForMember(s => s.Addresses, opt => opt.Ignore())
                .ForMember(s => s.Emails, opt => opt.Ignore())
                .ForMember(s => s.PhoneNumbers, opt => opt.Ignore());
        }
    }
}