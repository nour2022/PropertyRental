using PropertyRental.Domain.Entities.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Domain.Entities.User
{
    public class Owner : User
    {
        public List<Property.Property> OwnedProperies { get; set; }
    }
}
