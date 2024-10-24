using PropertyRental.Domain.Entities.Payment;
using PropertyRental.Domain.Entities.User;

namespace PropertyRental.Application.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public DateOnly PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod paymentMethod { get; set; }
        public int tenantId { get; set; }
        public int Propertyid { get; set; }
        public PaymentStatus PayementStatus { get; set; }

    }
}