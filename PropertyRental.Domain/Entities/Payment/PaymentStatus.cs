using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Domain.Entities.Payment
{
    public enum PaymentStatus
    {
        Pending,     // Payment is awaiting processing
        Completed,   // Payment has been successfully completed
        Failed,      // Payment has failed
        Overdue,     // Payment is past the due date
        Refunded      // Payment has been refunded
    }
}
