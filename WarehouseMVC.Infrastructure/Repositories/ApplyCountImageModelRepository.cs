using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Infrastructure.Repositories
{
    public class ApplyCountImageModelRepository : IApplyCountImageModelRepository
    {
        private readonly Context _context;

        public ApplyCountImageModelRepository(Context context)
        {
            _context = context;
        }

        public int AddApplyCountImageModel(ApplyCountImageModel applyCount)
        {
            _context.ApplyCountImageModels.AddAsync(applyCount);
            _context.SaveChangesAsync();
            return applyCount.Id;
        }

        public void UpdateApplyCountImageModel(ApplyCountImageModel apply)
        {

            _context.Attach(apply);
            _context.Entry(apply).Property("Id").IsModified = false;

            _context.Entry(apply).Property("FinallCount").IsModified = true;
            _context.Entry(apply).Property("ApplyCount").IsModified = true;

            _context.SaveChanges();
        }
    }
}