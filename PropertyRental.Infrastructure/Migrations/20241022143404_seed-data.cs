using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PropertyRental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Address_Addressid",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "Addressid",
                table: "Properties",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_Addressid",
                table: "Properties",
                newName: "IX_Properties_AddressId");

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "id", "ApartmentNumber", "City", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, "1A", "Sunshine City", "90001", "CA", "123 Sun St." },
                    { 2, "15B", "Wave Town", "33010", "FL", "456 Ocean Dr." }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Owner", "OWNER" },
                    { 3, null, "Tenant", "TENANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "9d301114-4b04-4765-902b-efbf4c6a7105", "User", "admin@example.com", false, "Admin User", "https://static.vecteezy.com/system/resources/previews/012/210/707/non_2x/worker-employee-businessman-avatar-profile-icon-vector.jpg", false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEP9Kj4gG7BCyMRCcDN+Z0t+bS7tjPzi3I3EaXwq/eES+MQzUY9PFd1lSd33IB+nO5w==", "111-111-1111", false, 1, "671b952e-8dfe-418c-bee4-0f81c2c88f92", false, "admin" },
                    { 2, 0, "1c1f2832-3a42-46fe-a371-b4de0ea12d1f", "User", "owner@example.com", false, "Owner User1", "https://www.clipartmax.com/png/middle/319-3191274_male-avatar-admin-profile.png", false, null, "OWNER@EXAMPLE.COM", "OWNER", "AQAAAAIAAYagAAAAEO5mFvkPOnWd/+FfsID3i+V7hrr+onNbYsPbPo2jyi6Dz+Oii6f8Hcl4Lk7f7Wf8LA==", "222-222-2222", false, 2, "0d4e283a-b915-41f1-841c-10f1ed7e66c1", false, "owner" },
                    { 3, 0, "dc2454fe-e637-409f-a95c-5fb874273b39", "User", "tenant@example.com", false, "Tenant User1", "https://lh4.googleusercontent.com/proxy/ElNJBofC5Bx_BPHcyLtNKL6tb90TKY0O1RzSW4i8UB7ZzuVGqitPVR43wJbwCxCPwaNPCTmNhsp3PTEXaza1NivZS2LdfGHBqqDfmInrTtO_K1g8", false, null, "TENANT@EXAMPLE.COM", "TENANT", "AQAAAAIAAYagAAAAELKAgfBfeIbvrOWNqy8uXspwbYtrm55VvX4IkoosT2fezVEllLVt6fmNLiuTkIVZww==", "333-333-3333", false, 3, "e8b5eb4c-8bf4-4b0b-a33c-16ac8fb3e7df", false, "tenant" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "LeaseAgreements",
                columns: new[] { "Id", "EndDate", "IsActive", "MonthelyRent", "PropertyId", "StartDate", "TenantId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 12, 31), true, 1500.00m, 1, new DateOnly(2024, 1, 1), 1 },
                    { 2, new DateOnly(2024, 4, 30), true, 2500.00m, 2, new DateOnly(2023, 5, 1), 2 }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "AddressId", "Description", "Image", "Name", "OwnerId", "PropertyType", "RentAmount", "Status" },
                values: new object[,]
                {
                    { 1, 1, "A cozy apartment with great sunlight and modern amenities.", "https://sunnyaparts.com/wp-content/uploads/2023/10/EXT_1-1-min-scaled.jpg", "Sunny Apartment", 1, 0, 1500.00m, 0 },
                    { 2, 2, "Luxury House with a view of the ocean and a private pool.", "https://as1.ftcdn.net/v2/jpg/01/72/73/22/1000_F_172732229_HKlHEGfEt2x9pRSHavBvcGEg59CRF45M.jpg", "Ocean View House", 2, 1, 2500.00m, 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Address_AddressId",
                table: "Properties",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Address_AddressId",
                table: "Properties");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "LeaseAgreements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaseAgreements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Properties",
                newName: "Addressid");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_AddressId",
                table: "Properties",
                newName: "IX_Properties_Addressid");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Address_Addressid",
                table: "Properties",
                column: "Addressid",
                principalTable: "Address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
