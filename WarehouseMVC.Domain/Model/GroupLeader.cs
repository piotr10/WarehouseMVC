using System.Collections.Generic;

namespace WarehouseMVC.Domain.Model
{
    public class GroupLeader
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Relations with ImageModel One to Many
        public virtual ICollection<ImageModel> ImageModels { get; set; }
    }
}