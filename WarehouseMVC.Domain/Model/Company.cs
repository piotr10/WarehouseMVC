using System.Collections.Generic;

namespace WarehouseMVC.Domain.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Relations with Questionnaire One to Many
        public virtual ICollection<ImageModel> ImageModels { get; set; }
        public virtual ICollection<Questionnaire> Questionnaires { get; set; }
    }
}