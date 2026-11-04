using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using WarehouseMVC.Application.Interfaces;
using WarehouseMVC.Application.ViewModel.Customer;
using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public int AddCustomer(NewCustomerVm customer)
        {
            var cust = _mapper.Map<Customer>(customer);
            var id = _customerRepo.AddCustomer(cust);
            return id;
        }

        public void DeleteCustomer(int id)
        {
            _customerRepo.DeleteCustomer(id);
        }

        /*
public void DeleteCustomer(int id)
{
   _customerRepo.DeleteCustomer(id);
}
*/
        #region Stara wersja przed Automapperem
        /*
        public ListCustomerForListVm GetAllCustomerForList() //Pobieramy wszystkich Aktywnych Customerów
        {
            var customers = _customerRepo.GetAllActiveCustomers(); //chcemy pobrać wszystkich aktywnych klientów zapisanych w bazie danych
            ListCustomerForListVm result = new ListCustomerForListVm(); //ViewModel dla listy customerów
            result.Customers = new List<CustomerForListVm>(); // inicjalizacja pojedyńczych elementów w liście
            foreach (var customer in customers) // iterujemy po wszystkich bazodanowych klientach / po liście klientów pobranych z bazy danych
            {
                var custVm = new CustomerForListVm() //dla każdego elementu tworzymy nowy ViewModel w którym pobierzemy sobie informacje które nas interesują
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    NIP = customer.NIP
                };
                result.Customers.Add(custVm); //dodajemy elemenet do listy ViewModeli
            }
            result.Count = result.Customers.Count; // zapisujemy jaka jest ilość customerów na tej liście
            return result;
        }
        */
        #endregion

        //Po dodaniu AutoMappera metoda (GetAllCustomerForList) będzie miałą taką postać:
        public ListCustomerForListVm GetAllCustomerForList(int pageSize, int pageNo, string searchString) //Pobieramy wszystkich Aktywnych Customerów
        {
            var customers = _customerRepo.GetAllActiveCustomers().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider).ToList();
            var customerToShow = customers.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var customerList = new ListCustomerForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Customers = customerToShow,
                Count = customers.Count
            };
            return customerList;
        }

        public CustomerDetailsVm GetCustomerDetails(int customerId)
        {
            var customer = _customerRepo.GetCustomer(customerId); //pobieramy odpowiedniego customera
            //Po dodaniu AutoMappera poniższy ViewModel bedzie miał taką postać:
            var customerVm = _mapper.Map<CustomerDetailsVm>(customer);

            #region Stara wersja przed Automapperem
            /*
            var customerVm = new CustomerDetailsVm(); //ViewModel który zwracamy
            //przypisanie pól z Entity do pól z ViewModelu
            customerVm.Id = customer.Id;
            customerVm.Name = customer.Name;
            customerVm.NIP = customer.NIP;
            customerVm.REGON = customer.Regon;
            customerVm.CEOFullName = customer.CEOName + " " + customer.CEOLastName; //z Tabeli Customer dane CEOName oraz CEOLastName pobrane do tabeli CustomerDetailsVm do danej CEOFullName
            var custConInfo = customer.CustomerContactInformation; //do nowej zmiennej custConInfo przypisujemy referenję do tego obiektu CustomerContactInformation
            customerVm.FirstLineOfCont actInformation = custConInfo.FirstName + " " + custConInfo.LastName; //z Tabeli CustomerContactInformation dane FirstName oraz LastName
                                                                                                           //pobrane do tabeli CustomerDetailsVm do danej FirstLineOfContactInformation
            */
            #endregion

            customerVm.Addresses = new List<AddressForListVm>(); //przechowujemy informacje o adresach
            customerVm.PhoneNumbers = new List<ContactDetailListVm>(); // informacje o numerach telefonów
            customerVm.Emails = new List<ContactDetailListVm>(); // informacje o emailach

            //iterowanie dla Addresses (to samo powinnyśmy zrobić dla PhoneNumber oraz Emails!)
            foreach (var address in customerVm.Addresses) // iterujemy po wszystkich bazodanowych adresach / po liście adresów pobranej z bazy danych
            {
                var add = new AddressForListVm() //dla każdego elementu tworzymy nowy ViewModel w którym pobierzemy sobie informacje które nas interesują
                {
                    Id = address.Id,
                    Country = address.Country,
                    City = address.City

                };
                customerVm.Addresses.Add(add); //dodajemy informację do naszego nadrzędnego ViewModelu
            }
            return customerVm;
        }

        public NewCustomerVm GetCustomerForEdit(int id)
        {
            var customer = _customerRepo.GetCustomer(id);
            var customerVm = _mapper.Map<NewCustomerVm>(customer);
            return customerVm;
        }

        public void UpdateCustomer(NewCustomerVm model)
        {
            var customer = _mapper.Map<Customer>(model);
            _customerRepo.UpdateCustomer(customer);
        }
    }
}