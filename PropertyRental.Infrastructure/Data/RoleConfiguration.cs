using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PropertyRental.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Infrastructure.Data
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
            builder.HasData(new Role
            {
                Id = 2,
                Name = "Owner",
                NormalizedName = "OWNER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
            builder.HasData(new Role
            {
                Id = 3,
                Name = "Tenant",
                NormalizedName = "TENANT",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
        }
    }
}
