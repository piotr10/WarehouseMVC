using Microsoft.AspNetCore.Http;
using WarehouseMVC.Application.ViewModel.Image;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application.Interfaces
{
    public interface IImageModelService
    {
        ListImageModelForListVm GetAllImageModelForList(int pageSize, int pageNo, string searchString);
        int AddImageModel(NewImageModelVm imageModel, IFormFile[] attachments);
        ImageModelDetailsVm GetImageModelDetails(int? id);
        void DeleteImageModel(int id);
        NewImageModelVm GetImageModelForEdit(int id);
        void UpdateImageModel(NewImageModelVm model);
    }
}