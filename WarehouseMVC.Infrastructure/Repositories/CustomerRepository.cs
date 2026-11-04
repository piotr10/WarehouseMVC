using System.Linq;
using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;
        public CustomerRepository(Context context)
        {
            _context = context;
        }
        public int AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer.Id;
        }

        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public IQueryable<Customer> GetAllActiveCustomers()
        {
            //return _context.Customers.Where(p => p.IsActive);
            return _context.Customers;
        }

        public Customer GetCustomer(int customerId)
        {
            return _context.Customers.FirstOrDefault(p => p.Id == customerId);
        }
        public void UpdateCustomer(Customer customer)
        {
            _context.Attach(customer);
            _context.Entry(customer).Property("Name").IsModified = true;
            _context.Entry(customer).Property("NIP").IsModified = true;
            _context.Entry(customer).Property("Regon").IsModified = true;
            _context.SaveChanges();
        }
    }
}