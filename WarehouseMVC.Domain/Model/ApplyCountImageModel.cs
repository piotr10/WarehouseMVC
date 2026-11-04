using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace WarehouseMVC.Domain.Model
{
    public class ApplyCountImageModel
    {
        public int Id { get; set; }
        [DisplayName("Actually count of applications")]
        public int FinallCount { get; set; }
        [DisplayName("Max count of applications")]
        public int ApplyCount { get; set; }
    }
}