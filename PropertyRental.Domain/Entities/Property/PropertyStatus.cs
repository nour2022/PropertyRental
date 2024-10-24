using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Domain.Entities.Property
{
    public enum PropertyStatus
    {
        Available,           // Property is available for rent
        Rented,              // Property is currently rented
        UnderMaintenance,    // Property is under maintenance
        NotAvailable,        // Property is not available for rental (e.g., withdrawn from the market)
        Sold,                // Property has been sold
        Reserved             // Property is reserved for a tenant but not yet finalized

    }
}
