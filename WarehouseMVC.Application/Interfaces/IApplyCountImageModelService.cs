using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application.Interfaces
{
    public interface IApplyCountImageModelService
    {
        void UpdateImageModel(ApplyCountImageModel apply);
        int AddApplyCountImageModel(ApplyCountImageModel applyCount);
    }
}