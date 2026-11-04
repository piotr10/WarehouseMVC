namespace WarehouseMVC.Domain.Model
{
    public class CustomerContactInformation // dane kontaktowe do osoby reprezentującej firmę / klienta
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; } //pozycja zajmowana w firmie przez tą osobę
        public int CustomerRef { get; set; }
        public Customer Customer { get; set; }
    }
}