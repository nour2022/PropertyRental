using PropertyRental.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Application.DTOs
{
    public class LeaseAgreementDTO
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public TenantDTO Tenant { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal MonthelyRent { get; set; }
        public bool IsActive { get; set; }
    }
}
