using System.Collections.Generic;

namespace WarehouseMVC.Application.ViewModel.Image
{
    public class ListImageModelForListVm
    {
        public List<ImageForListVm> ImageModels { get; set; }

        // For pagination
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; } 
    }
}