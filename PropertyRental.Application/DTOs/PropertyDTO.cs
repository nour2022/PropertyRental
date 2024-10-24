using PropertyRental.Domain.Entities.Property;
using PropertyRental.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Application.DTOs
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal RentAmount { get; set; }
        public int OwnerId { get; set; }
        public PropertyType PropertyType { get; set; }
        public PropertyStatus Status { get; set; }
    }
}
