using System.Collections.Generic;

namespace WarehouseMVC.Application.ViewModel.Contact
{
    public class ListContactForListVm
    {
        public List<ContactForListVm> Contacts { get; set; }

        // For pagination
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}