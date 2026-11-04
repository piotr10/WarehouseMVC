using System.Linq;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Domain.Interfaces
{
    public interface IImageModelRepository
    {
        IQueryable<ImageModel> GetAllImageModel();
        ImageModel GetImageModel(int? imageModelId);
        int AddImageModel(ImageModel imageModel);
        IQueryable<Company> GetImageModelByCompanyId(int companyId);
        IQueryable<Company> GetAllCompany();
        void DeleteImageModel(int id);
        void UpdateImageModel(ImageModel imageModel);
    }
}