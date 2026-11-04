using System.Linq;
using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Infrastructure.Repositories
{
    public class ImageModelRepository : IImageModelRepository
    {
        private readonly Context _context;
        public ImageModelRepository(Context context)
        {
            _context = context;
        }

        //AddImageModel
        public int AddImageModel(ImageModel imageModel)
        {
            _context.Images.AddAsync(imageModel);
            _context.SaveChangesAsync();
            return imageModel.Id;
        }

        //DeleteImageModel
        public void DeleteImageModel(int id)
        {
            var imageModel = _context.Images.Find(id);
            if (imageModel != null)
            {
                _context.Images.Remove(imageModel);
                _context.SaveChanges();
            }
        }

        //GetAllImageModel
        public IQueryable<ImageModel> GetAllImageModel()
        {
            //var imageModel = _context.Images.Where(p => p.IsActive);
            var imageModel = _context.Images;
            return imageModel;
        }

        //GetImageModel
        public ImageModel GetImageModel(int? imageModelId)
        {
            var imageModel = _context.Images.FirstOrDefault(p => p.Id == imageModelId);
            return imageModel;
        }

        //UpdateImageModel
        public void UpdateImageModel(ImageModel imageModel)
        {
            _context.Attach(imageModel);
            _context.Entry(imageModel).Property("Id").IsModified = false;

            #region IsModified = true
            _context.Entry(imageModel).Property("Address").IsModified = true;
            _context.Entry(imageModel).Property("AddFrom").IsModified = true;
            _context.Entry(imageModel).Property("Email").IsModified = true;
            _context.Entry(imageModel).Property("Name").IsModified = true;
            _context.Entry(imageModel).Property("Phone").IsModified = true;
            _context.Entry(imageModel).Property("Subject").IsModified = true;
            _context.Entry(imageModel).Property("Surname").IsModified = true;
            _context.Entry(imageModel).Property("IsHired").IsModified = true;
            _context.Entry(imageModel).Property("AcceptHiredRecruitment").IsModified = true;
            _context.Entry(imageModel).Property("AcceptHiredControlling").IsModified = true;
            _context.Entry(imageModel).Property("AcceptHiredCfo").IsModified = true;
            _context.Entry(imageModel).Property("EmploymentDate").IsModified = true;
            _context.Entry(imageModel).Property("EmployedUnder").IsModified = true;
            _context.Entry(imageModel).Property("FinallyHiredPayroll").IsModified = true;
            _context.Entry(imageModel).Property("FinallyHiredPayrollFalse").IsModified = true;
            _context.Entry(imageModel).Property("ReasonDenied").IsModified = true;
            _context.Entry(imageModel).Property("Price").IsModified = true;
            _context.Entry(imageModel).Property("CompatibleHarmonogram").IsModified = true;
            _context.Entry(imageModel).Property("AddHoc").IsModified = true;
            _context.Entry(imageModel).Property("Rotation").IsModified = true;
            _context.Entry(imageModel).Property("CompanyId").IsModified = true;
            _context.Entry(imageModel).Property("GroupManagerId").IsModified = true;
            _context.Entry(imageModel).Property("GroupLeaderId").IsModified = true;
            _context.Entry(imageModel).Property("AcceptDateTimeRecruitment").IsModified = true;
            _context.Entry(imageModel).Property("AcceptDateTimeControlling").IsModified = true;
            _context.Entry(imageModel).Property("AcceptDateTimeCfo").IsModified = true;
            //_context.Entry(imageModel).Property("GroupManager").IsModified = true;
            //_context.Entry(imageModel).Property("GroupLeader").IsModified = true;

            _context.Entry(imageModel).Property("Status").IsModified = true;
            #endregion

            _context.SaveChanges();
        }

        //GetImageModelByCompanyId
        public IQueryable<Company> GetImageModelByCompanyId(int companyId)
        {
            var company = _context.Companies.Where(i => i.Id == companyId);
            return company;
        }

        //GetAllCompany
        public IQueryable<Company> GetAllCompany()
        {
            var company = _context.Companies;
            return company;
        }
    }
}