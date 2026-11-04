using System.Linq;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Domain.Interfaces
{
    public interface IContactRepository
    {
        IQueryable<Contact> GetAllContact();
    }
}