using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Domain.Interfaces
{
    public interface IApplyCountImageModelRepository
    {
        int AddApplyCountImageModel(ApplyCountImageModel applyCount);
        void UpdateApplyCountImageModel(ApplyCountImageModel questionnaire);
    }
}