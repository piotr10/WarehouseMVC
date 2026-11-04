using WarehouseMVC.Application.ViewModel.Customer;

namespace WarehouseMVC.Application.Interfaces
{//interfeks dla servisu związanego z klientami
    public interface ICustomerService
    {
        ListCustomerForListVm GetAllCustomerForList(int pageSize, int pageNo, string searchString); // elementem zwracanym jest lista moich Customerów związana z VewModelem dla listy
        int AddCustomer(NewCustomerVm customer); //zwracany id nowego klienta
        CustomerDetailsVm GetCustomerDetails(int customerId);
        //void DeleteCustomer(int id);

        //void UpdateCustomer(NewCustomerVm model);
        NewCustomerVm GetCustomerForEdit(int id);
        void UpdateCustomer(NewCustomerVm model);
        void DeleteCustomer(int id);
    }
}