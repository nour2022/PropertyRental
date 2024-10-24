using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyRental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab087c4b-9369-4c04-b69e-374eebc767b6", "AQAAAAIAAYagAAAAELJ9Mxy+ID3DeSYjsvngURIAS55oSyi3yrysaWy5u889M4w9wjXKCc5bqBPeCroG+A==", "9d7660e0-250e-4372-a07c-65b9bab9c7b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "116ffdee-3b4a-4191-8ed8-ef71d5aebe8c", "AQAAAAIAAYagAAAAELDYymswQqFcv2sp/OHPud9Teq3Veb3tiZMf6OlBrortkhvASIh7RNaNjufC4sM/Lw==", "ab2edd6d-3756-4523-b9ba-d7a7524cf722" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8cb6243a-b9b5-4ec2-a53d-c2edf1ae5857", "AQAAAAIAAYagAAAAEC6WlDeMYAp8114ujfZLQCE2Bkunneo5pWH3jSNjk4Ik4RHzrOCAxqVRHkG5OZ3d3w==", "54c5f1a1-b122-469c-a74d-45e528e1ad74" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d301114-4b04-4765-902b-efbf4c6a7105", "AQAAAAIAAYagAAAAEP9Kj4gG7BCyMRCcDN+Z0t+bS7tjPzi3I3EaXwq/eES+MQzUY9PFd1lSd33IB+nO5w==", "671b952e-8dfe-418c-bee4-0f81c2c88f92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c1f2832-3a42-46fe-a371-b4de0ea12d1f", "AQAAAAIAAYagAAAAEO5mFvkPOnWd/+FfsID3i+V7hrr+onNbYsPbPo2jyi6Dz+Oii6f8Hcl4Lk7f7Wf8LA==", "0d4e283a-b915-41f1-841c-10f1ed7e66c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc2454fe-e637-409f-a95c-5fb874273b39", "AQAAAAIAAYagAAAAELKAgfBfeIbvrOWNqy8uXspwbYtrm55VvX4IkoosT2fezVEllLVt6fmNLiuTkIVZww==", "e8b5eb4c-8bf4-4b0b-a33c-16ac8fb3e7df" });
        }
    }
}
