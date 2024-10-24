﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyRental.Infrastructure.Data;

#nullable disable

namespace PropertyRental.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241022143404_seed-data")]
    partial class seeddata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PropertyRental.Domain.Entities.LeaseAgreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("MonthelyRent")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("LeaseAgreements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateOnly(2024, 12, 31),
                            IsActive = true,
                            MonthelyRent = 1500.00m,
                            PropertyId = 1,
                            StartDate = new DateOnly(2024, 1, 1),
                            TenantId = 1
                        },
                        new
                        {
                            Id = 2,
                            EndDate = new DateOnly(2024, 4, 30),
                            IsActive = true,
                            MonthelyRent = 2500.00m,
                            PropertyId = 2,
                            StartDate = new DateOnly(2023, 5, 1),
                            TenantId = 2
                        });
                });

            modelBuilder.Entity("PropertyRental.Domain.Entities.Payment.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("PayementStatus")
                        .HasColumnType("int");

                    b.Property<DateOnly>("PaymentDate")
                        .HasColumnType("date");

                    b.Property<int>("Propertyid")
                        .HasColumnType("int");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<int>("paymentMethod")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Propertyid");

                    b.HasIndex("TenantId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("PropertyRental.Domain.Entities.Property.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("ApartmentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            id = 1,
                            ApartmentNumber = "1A",
                            City = "Sunshine City",
                            PostalCode = "90001",
                            State = "CA",
                            Street = "123 Sun St."
                        },
                        new
                        {
                            id = 2,
                            ApartmentNumber = "15B",
                            City = "Wave Town",
                            PostalCode = "33010",
                            State = "FL",
                            Street = "456 Ocean Dr."
                        });
                });

            modelBuilder.Entity("PropertyRental.Domain.Entities.Property.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyType")
                        .HasColumnType("int");

                    b.Property<decimal>("RentAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Properties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            Description = "A cozy apartment with great sunlight and modern amenities.",
                            Image = "https://sunnyaparts.com/wp-content/uploads/2023/10/EXT_1-1-min-scaled.jpg",
                            Name = "Sunny Apartment",
                            OwnerId = 1,
                            PropertyType = 0,
                            RentAmount = 1500.00m,
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            Description = "Luxury House with a view of the ocean and a private pool.",
                            Image = "https://as1.ftcdn.net/v2/jpg/01/72/73/22/1000_F_172732229_HKlHEGfEt2x9pRSHavBvcGEg59CRF45M.jpg",
                            Name = "Ocean View House",
                            OwnerId = 2,
                            PropertyType = 1,
                            RentAmount = 2500.00m,
                            Status = 1
                        });
                });

            modelBuilder.Entity("PropertyRental.Domain.Entities.User.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Owner",
                            NormalizedName = "OWNER"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tenant",
                            NormalizedName = "TENANT"
                        });
                });

            modelBuilder.Entity("PropertyRental.Domain.Entities.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("User");

                    b.UseTphMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9d301114-4b04-4765-902b-efbf4c6a7105",
                            Email = "admin@example.com",
                            EmailConfirmed = false,
                            FullName = "Admin User",
                            Image = "https://static.vecteezy.com/system/resources/previews/012/210/707/non_2x/worker-employee-businessman-avatar-profile-icon-vector.jpg",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@EXAMPLE.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEP9Kj4gG7BCyMRCcDN+Z0t+bS7tjPzi3I3EaXwq/eES+MQzUY9PFd1lSd33IB+nO5w==",
                            PhoneNumber = "111-111-1111",
                            PhoneNumberConfirmed = false,
                            RoleId = 1,
                            SecurityStamp = "671b952e-8dfe-418c-bee4-0f81c2c88f92",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1c1f2832-3a42-46fe-a371-b4de0ea12d1f",
                            Email = "owner@example.com",
                            EmailConfirmed = false,
                            FullName = "Owner User1",
                            Image = "https://www.clipartmax.com/png/middle/319-3191274_male-avatar-admin-profile.png",
                            LockoutEnabled = false,
                            NormalizedEmail = "OWNER@EXAMPLE.COM",
                            NormalizedUserName = "OWNER",
                            PasswordHash = "AQAAAAIAAYagAAAAEO5mFvkPOnWd/+FfsID3i+V7hrr+onNbYsPbPo2jyi6Dz+Oii6f8Hcl4Lk7f7Wf8LA==",
                            PhoneNumber = "222-222-2222",
                            PhoneNumberConfirmed = false,
                            RoleId = 2,
                            SecurityStamp = "0d4e283a-b915-41f1-841c-10f1ed7e66c1",
                            TwoFactorEnabled = false,
                            UserName = "owner"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "dc2454fe-e637-409f-a95c-5fb874273b39",
                            Email = "tenant@example.com",
                            EmailConfirmed = false,
                            FullName = "Tenant User1",
                            Image = "https://lh4.googleusercontent.com/proxy/ElNJBofC5Bx_BPHcyLtNKL6tb90TKY0O1RzSW4i8UB7ZzuVGqitPVR43wJbwCxCPwaNPCTmNhsp3PTEXaza1NivZS2LdfGHBqqDfmInrTtO_K1g8",
                            LockoutEnabled = false,
                            NormalizedEmail = "TENANT@EXAMPLE.COM",
                            NormalizedUserName = "TENANT",
                            PasswordHash = "AQAAAAIAAYagAAAAELKAgfBfeIbvrOWNqy8uXspwbYtrm55VvX4IkoosT2fezVEllLVt6fmNLiuTkIVZww==",
                            PhoneNumber = "333-333-3333",
                            PhoneNumberConfirmed = false,
                            RoleId = 3,
                            SecurityStamp = "e8b5eb4c-8bf4-4b0b-a33c-16ac8fb3e7df",
                            TwoFactorEnabled = false,
                            UserName = "tenant"
                        });
                });

            modelBuilder.Entity("PropertyRental.Domain.Entities.User.Owner", b =>
                {
                    b.HasBaseType("PropertyRental.Domain.Entities.User.User");

                    b.HasDiscriminator().HasValue("Owner");
                });

            modelBuilder.Entity("PropertyRental.Domain.Entities.User.Tenant", b =>
                {
                    b.HasBaseType("PropertyRental.Domain.Entities.User.User");

                    b.Property<int>("paymentMethod")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Tenant");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("PropertyRental.Domain.Entities.User.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("PropertyRental.Domain.Entities.User.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("PropertyRental.Domain.Entities.User.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("PropertyRental.Domain.Entities.User.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PropertyRental.Domain.Entities.User.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("PropertyRental.Domain.Entities.User.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PropertyRental.Domain.Entities.LeaseAgreement", b =>
                {
                    b.HasOne("PropertyRental.Domain.Entities.User.Tenant", "Tenant")
                        .WithMany("LeaseAgreements")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("PropertyRental.Domain.Entities.Payment.Payment", b =>
                {
                    b.HasOne("PropertyRental.Domain.Entities.Property.Property", "Property")
                        .WithMany("Payments")
                        .HasForeignKey("Propertyid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PropertyRental.Domain.Entities.User.Tenant", "Tenant")
                        .WithMany("Payments")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("PropertyRental.Domain.Entities.Property.Property", b =>
                {
                    b.HasOne("PropertyRental.Domain.Entities.Property.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PropertyRental.Domain.Entities.User.Owner", "Owner")
                        .WithMany("OwnedProperies")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("PropertyRental.Domain.Entities.User.User", b =>
                {
                    b.HasOne("PropertyRental.Domain.Entities.User.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PropertyRental.Domain.Entities.Property.Property", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("PropertyRental.Domain.Entities.User.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("PropertyRental.Domain.Entities.User.Owner", b =>
                {
                    b.Navigation("OwnedProperies");
                });

            modelBuilder.Entity("PropertyRental.Domain.Entities.User.Tenant", b =>
                {
                    b.Navigation("LeaseAgreements");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
