using System.Linq;
using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;
        public ContactRepository(Context context)
        {
            _context = context;
        }
        public IQueryable<Contact> GetAllContact()
        {
            var contact = _context.Contacts;
            return contact;
        }
    }
}