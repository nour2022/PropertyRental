using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PropertyRental.Domain.Entities.Property;
using PropertyRental.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Domain.Entities.Payment
{
    public class Payment
    {
        public int Id { get; set; }
        public DateOnly PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod paymentMethod { get; set; }
        public Tenant Tenant { get; set; }
        public Property.Property Property { get; set; }
        public int Propertyid { get; set; }
        public PaymentStatus PayementStatus { get; set; }
    }
}
