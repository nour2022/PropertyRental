using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Domain.Entities.Property
{
    public class Address
    {
        public int id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string? State { get; set; }
        public string PostalCode { get; set; }
        public string? ApartmentNumber { get; set; }

    }
}
