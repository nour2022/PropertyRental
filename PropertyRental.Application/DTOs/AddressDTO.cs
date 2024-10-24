namespace PropertyRental.Application.DTOs
{
    public class AddressDTO
    {
        public int id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string? State { get; set; }
        public string PostalCode { get; set; }
        public string? ApartmentNumber { get; set; }
    }
}