using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mango.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class defaultUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad376a8f-9eab-4bb9-9fca-30b01540f445", null, "ADMIN", "ADMIN" },
                    { "bd376a8f-9eab-4bb9-9fca-30b01540f445", null, "CUSTOMER", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "5edd3d49-dc69-4047-8503-c8faa36f0b4b", "admin@gmail.com", false, true, null, "Admin", "admin@gmail.com", "admin", "AQAAAAIAAYagAAAAEFIPGRqEfX+F0OGO3LPYc/y5evCJdy107CWnPASMXipyQGZPcycUIVVeuCohGTsBAA==", null, false, "656b7c67-617e-45d7-9e3f-2a49bc761e62", false, "admin" },
                    { "b18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "8c8edb23-0528-43cf-ae83-ea4af90aa87b", "customer@gmail.com", false, true, null, "Customer", "customer@gmail.com", "customer", "AQAAAAIAAYagAAAAEAofM7AhUw+60qBs1Sf8f7mddf4SqITLz9D8s5fj84OCH7k/zY7hkcLM/9TO3DUwIg==", null, false, "1c84499a-52b5-496a-a7b1-b57d1b3c774f", false, "customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ad376a8f-9eab-4bb9-9fca-30b01540f445", "a18be9c0-aa65-4af8-bd17-00bd9344e575" },
                    { "bd376a8f-9eab-4bb9-9fca-30b01540f445", "b18be9c0-aa65-4af8-bd17-00bd9344e575" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f445", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd376a8f-9eab-4bb9-9fca-30b01540f445", "b18be9c0-aa65-4af8-bd17-00bd9344e575" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f445");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd376a8f-9eab-4bb9-9fca-30b01540f445");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-00bd9344e575");
        }
    }
}
