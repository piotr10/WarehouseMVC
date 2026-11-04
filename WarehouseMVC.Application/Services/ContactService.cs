using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using WarehouseMVC.Application.Interfaces;
using WarehouseMVC.Application.ViewModel.Contact;
using WarehouseMVC.Application.ViewModel.Image;
using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public ListContactForListVm GetAllContactForList(int pageSize, int pageNo, string searchString)
        {
            var imageModel = _contactRepository.GetAllContact()
                .Where(p => p.Name.StartsWith(searchString) | p.Surname.StartsWith(searchString)).ProjectTo<ContactForListVm>(_mapper.ConfigurationProvider).ToList();


            var imageToShow = imageModel.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var contactList = new ListContactForListVm()
            {
                Contacts = imageToShow,
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Count = imageModel.Count
            };

            return contactList;
        }
    }
}