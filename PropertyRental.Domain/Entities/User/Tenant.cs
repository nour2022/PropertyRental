using PropertyRental.Domain.Entities.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Domain.Entities.User
{
    public class Tenant : User
    {
        public List<LeaseAgreement>? LeaseAgreements { get; set; }
        public List<Payment.Payment>? Payments { get; set; }

        public PaymentMethod paymentMethod { get; set; }
    }
}
