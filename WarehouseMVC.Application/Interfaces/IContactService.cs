using WarehouseMVC.Application.ViewModel.Contact;

namespace WarehouseMVC.Application.Interfaces
{
    public interface IContactService
    {
        ListContactForListVm GetAllContactForList(int pageSize, int pageNo, string searchString);
    }
}