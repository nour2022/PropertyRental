using PropertyRental.Domain.Entities.Payment;
using PropertyRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Application.DTOs
{
    public class TenantDTO:UserDTO
    {
        public List<LeaseAgreementDTO>? LeaseAgreements { get; set; }
        public List<PaymentDTO>? Payments { get; set; }

        public PaymentMethod paymentMethod { get; set; }
    }
}
