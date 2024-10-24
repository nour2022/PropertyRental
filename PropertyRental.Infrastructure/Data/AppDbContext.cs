using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PropertyRental.Domain.Entities;
using PropertyRental.Domain.Entities.Payment;
using PropertyRental.Domain.Entities.Property;
using PropertyRental.Domain.Entities.User;

namespace PropertyRental.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Property> Properties { get; set; }
        public DbSet<LeaseAgreement> LeaseAgreements { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           
                // Seed for Address
                modelBuilder.Entity<PropertyRental.Domain.Entities.Property.Address>().HasData(
                    new PropertyRental.Domain.Entities.Property.Address
                    {
                        id = 1,
                        Street = "123 Sun St.",
                        City = "Sunshine City",
                        State = "CA",
                        PostalCode = "90001",
                        ApartmentNumber = "1A"
                    },
                    new PropertyRental.Domain.Entities.Property.Address
                    {
                        id = 2,
                        Street = "456 Ocean Dr.",
                        City = "Wave Town",
                        State = "FL",
                        PostalCode = "33010",
                        ApartmentNumber = "15B"
                    }
                );

                
                // Seed for Property
                modelBuilder.Entity<PropertyRental.Domain.Entities.Property.Property>().HasData(
                    new PropertyRental.Domain.Entities.Property.Property
                    {
                        Id = 1,
                        Name = "Sunny Apartment",
                        Address = null, // You don't seed related entities directly here; relationships will be set based on foreign key.
                        AddressId = 1, // Ensure your Property model has an AddressId FK property.
                        Description = "A cozy apartment with great sunlight and modern amenities.",
                        Image = "https://sunnyaparts.com/wp-content/uploads/2023/10/EXT_1-1-min-scaled.jpg",
                        RentAmount = 1500.00m,
                        OwnerId = 1, // Add FK Property for Owner
                        PropertyType = PropertyType.Apartment,
                        Status = PropertyStatus.Available
                    },
                    new PropertyRental.Domain.Entities.Property.Property
                    {
                        Id = 2,
                        Name = "Ocean View House",
                        Address = null,
                        AddressId = 2,
                        Description = "Luxury House with a view of the ocean and a private pool.",
                        Image = "https://as1.ftcdn.net/v2/jpg/01/72/73/22/1000_F_172732229_HKlHEGfEt2x9pRSHavBvcGEg59CRF45M.jpg",
                        RentAmount = 2500.00m,
                        OwnerId = 2,
                        PropertyType = PropertyType.House,
                        Status = PropertyStatus.Rented
                    }
                );

                // Seed for LeaseAgreement
                modelBuilder.Entity<PropertyRental.Domain.Entities.LeaseAgreement>().HasData(
                    new PropertyRental.Domain.Entities.LeaseAgreement
                    {
                        Id = 1,
                        PropertyId = 1,
                        TenantId = 1, // Add FK for Tenant
                        StartDate = new DateOnly(2024, 01, 01),
                        EndDate = new DateOnly(2024, 12, 31),
                        MonthelyRent = 1500.00m,
                        IsActive = true
                    },
                    new PropertyRental.Domain.Entities.LeaseAgreement
                    {
                        Id = 2,
                        PropertyId = 2,
                        TenantId = 2, // Add FK for Tenant
                        StartDate = new DateOnly(2023, 05, 01),
                        EndDate = new DateOnly(2024, 04, 30),
                        MonthelyRent = 2500.00m,
                        IsActive = true
                    }
                );


            // Seed roles
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new Role
                {
                    Id = 2,
                    Name = "Owner",
                    NormalizedName = "OWNER"
                },
                new Role
                {
                    Id = 3,
                    Name = "Tenant",
                    NormalizedName = "TENANT"
                }
            );

            // Hashing the default password for users
            var hasher = new PasswordHasher<User>();

            // Seed users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    FullName = "Admin User",
                    RoleId = 1,
                    PasswordHash = hasher.HashPassword(null, "123"), // Use a secure password
                    PhoneNumber = "111-111-1111",
                    Image = "https://static.vecteezy.com/system/resources/previews/012/210/707/non_2x/worker-employee-businessman-avatar-profile-icon-vector.jpg",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new User
                {
                    Id = 2,
                    UserName = "owner",
                    NormalizedUserName = "OWNER",
                    Email = "owner@example.com",
                    NormalizedEmail = "OWNER@EXAMPLE.COM",
                    FullName = "Owner User1",
                    RoleId = 2,
                    PasswordHash = hasher.HashPassword(null, "123"),
                    PhoneNumber = "222-222-2222",
                    Image = "https://www.clipartmax.com/png/middle/319-3191274_male-avatar-admin-profile.png",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new User
                {
                    Id = 3,
                    UserName = "tenant",
                    NormalizedUserName = "TENANT",
                    Email = "tenant@example.com",
                    NormalizedEmail = "TENANT@EXAMPLE.COM",
                    FullName = "Tenant User1",
                    RoleId = 3,
                    PasswordHash = hasher.HashPassword(null, "123"),
                    PhoneNumber = "333-333-3333",
                    Image = "https://lh4.googleusercontent.com/proxy/ElNJBofC5Bx_BPHcyLtNKL6tb90TKY0O1RzSW4i8UB7ZzuVGqitPVR43wJbwCxCPwaNPCTmNhsp3PTEXaza1NivZS2LdfGHBqqDfmInrTtO_K1g8",
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            );

            // Seed the relationship between Users and Roles (UserRoles)
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 }, // Admin User to Admin Role
                new IdentityUserRole<int> { UserId = 2, RoleId = 2 }, // Owner User to Owner Role
                new IdentityUserRole<int> { UserId = 3, RoleId = 3 }  // Tenant User to Tenant Role
            );


            modelBuilder.Entity<LeaseAgreement>()
                .Property(l => l.MonthelyRent)
                .HasColumnType("decimal(18, 2)"); // Adjust precision and scale as necessary

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18, 2)"); // Adjust precision and scale as necessary

            modelBuilder.Entity<Property>()
                .Property(p => p.RentAmount)
                .HasColumnType("decimal(18, 2)"); // Adjust precision and scale as necessary

            // Configure Identity relationships
            modelBuilder.Entity<IdentityUserRole<int>>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<User>()
                .HasOne(ur => ur.Role)
                .WithMany(u => u.Users) // Adjust accordingly
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete here

            modelBuilder.Entity<Payment>()
                .HasOne(e => e.Property)
                .WithMany(e => e.Payments)
                .HasForeignKey(e => e.Propertyid).OnDelete(DeleteBehavior.Restrict); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
