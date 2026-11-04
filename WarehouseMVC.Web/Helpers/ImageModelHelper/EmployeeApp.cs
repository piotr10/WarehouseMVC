using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using WarehouseMVC.Application.Interfaces;
using WarehouseMVC.Application.Services;
using WarehouseMVC.Application.ViewModel.Image;
using WarehouseMVC.Domain.Model;
using WarehouseMVC.Infrastructure;

namespace WarehouseMVC.Web.Helpers.ImageModelHelper
{
    public class EmployeeApp
    {
        private readonly Context _context;
        private readonly IApplyCountImageModelService _applyCountImageModelService;

        public EmployeeApp(Context context, IApplyCountImageModelService applyCountImageModelService)
        {
            _context = context;
            _applyCountImageModelService = applyCountImageModelService;
        }

        public async Task<int> EmployeeCheckApplication(NewImageModelVm imageModel, int resultApply, int result, List<ApplyCountImageModel> applyCount, ApplyCountImageModel ap)
        {

            if (imageModel.CompatibleHarmonogram == true && imageModel.AddHoc == false && imageModel.Rotation == false)
            {
                //Check employee application

                applyCount = (from apply1 in _context.ApplyCountImageModels
                    select apply1).ToList();

                var resultLastApplyCount = applyCount.LastOrDefault();
                result = resultLastApplyCount.FinallCount;

                var resultApplyCount = applyCount.LastOrDefault();
                resultApply = resultLastApplyCount.ApplyCount;

                var idResultApply = resultApplyCount.Id;

                var a = 1;

                result += a;
                if (result > resultApply)
                {
                    return 1;
                }

                else if (result <= resultApply)
                {
                    ap = new ApplyCountImageModel
                    {
                        ApplyCount = resultApply,
                        FinallCount = result
                    };

                    var id = _applyCountImageModelService.AddApplyCountImageModel(ap);
                    return 2;
                }
            }

            return 3;
        }
    }
}