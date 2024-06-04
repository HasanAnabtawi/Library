using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class AdminSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7330");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "71213656-375e-4f26-8cb9-fa34740e6691", 0, "Amman", "1394d109-071d-4d0c-a633-194b9a51afc6", "Hasan@hh.com", false, true, null, "Hasan", "HASAN@HH.COM", "HASAN", "AQAAAAIAAYagAAAAECYGjH+g2eH+sZATW3ca4lY7dfkFVVP0+wWciwheIPkvr3+l4hNXanxe/RQI4NuLKA==", null, false, "XN4MNXY2RIUVN6Q6U4IFRE3QMSTQO2J6", false, "Hasan" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71213656-375e-4f26-8cb9-fa34740e6691");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "2", "HR", "Human Resource" });
        }
    }
}
