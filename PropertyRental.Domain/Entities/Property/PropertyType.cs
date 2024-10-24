using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Domain.Entities.Property
{
    public enum PropertyType
    {
        Apartment,       // An apartment unit in a building
        House,           // A standalone house
        Townhouse,       // A townhouse that is part of a row of houses
        Condominium,     // A condo unit in a building with shared amenities
        Studio,          // A studio apartment with an open layout
        Duplex,          // A residential building divided into two separate living units
        Villa,           // A large and luxurious house
        Commercial,      // Commercial properties like offices, retail, etc.
        Land,            // Vacant land for sale or lease
        Industrial       // Properties for industrial use, like warehouses or factories

    }
}
