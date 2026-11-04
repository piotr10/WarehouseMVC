using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseMVC.Domain.Model
{
    public class Customer // jest to firma / klinet (nie człowiek) i jej podstawowe dane
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string Regon { get; set; }
        public string CEOName { get; set; }
        public string CEOLastName { get; set; }
        public bool IsActive { get; set; } //pokazuje nam czy dany klient powinien wyświetlać się w danej liście zamiast go kasować to się go dezaktuwuje i nie pokazuje na każdej liście      
        public byte[] LogoPic { get; set; }

        public CustomerContactInformation CustomerContactInformation { get; set; }
        public virtual ICollection<ContactDetail> ContactDetails { get; set; } // dzięki klasie ContactDetali + ContactDetailType opanowaliśmy normalizację bazy danych i 
                                                                               // przetrzymywanie informacji w jednej kolumnie (chodzi o numery telefonów klineta) 
        public virtual ICollection<Address> Addresses { get; set; } // dzięki klasie ContactDetali + ContactDetailType + Address opanowaliśmy normalizację bazy danych i 
                                                                    // przetrzymywanie informacji w jednej kolumnie (chodzi o numery telefonów klineta) 
    }
}
