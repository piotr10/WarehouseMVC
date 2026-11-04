namespace WarehouseMVC.Domain.Model
{
    public class ContactDetail // osoba kontaktowa z firmy (od Customer'a) //dane teleadresowe do klienta
    {
        public int Id { get; set; }
        public string ContactDetailInformation { get; set; } //tutaj będziemy zapisywać adresy mailowe i numery telefonów
        public int ContactDetailTypeId { get; set; }
        public ContactDetailType ContactDetailType { get; set; } // tu będziemy przetrzymywać informacje czy to jest nr telefonu czy nr fax czy adres email
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
} 