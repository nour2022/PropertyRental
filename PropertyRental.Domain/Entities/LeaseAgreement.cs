using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyRental.Domain.Entities.User;

namespace PropertyRental.Domain.Entities
{
    public class LeaseAgreement
    {
        [Key]
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public Tenant Tenant { get; set; }
        public int TenantId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal MonthelyRent { get; set; }
        public bool IsActive { get; set; }
    }
}
