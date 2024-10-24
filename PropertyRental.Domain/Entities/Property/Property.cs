using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyRental.Domain.Entities.User;

namespace PropertyRental.Domain.Entities.Property
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal RentAmount { get; set; }
        public Owner? Owner { get; set; }
        public int OwnerId { get; set; }
        public PropertyType PropertyType { get; set; }
        public PropertyStatus Status { get; set; }
        public List<Payment.Payment>? Payments { get; set; }
    }
}
