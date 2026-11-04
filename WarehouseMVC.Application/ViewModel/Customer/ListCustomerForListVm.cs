using System.Collections.Generic;

namespace WarehouseMVC.Application.ViewModel.Customer
{
    public class ListCustomerForListVm //Klasa która wyświetla listę moich klientów
    {
        public List<CustomerForListVm> Customers { get; set; }  //lista ViewModeli związanych z klientem
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }  //liczba klientów która zostanie zwrócona
    }
}