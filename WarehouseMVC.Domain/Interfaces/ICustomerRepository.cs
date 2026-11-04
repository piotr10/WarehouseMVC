using System.Linq;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetAllActiveCustomers(); //lista bazodanowych customerow
        Customer GetCustomer(int customerId);
        int AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}