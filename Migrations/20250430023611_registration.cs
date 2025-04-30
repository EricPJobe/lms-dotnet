using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace lms_server.Migrations
{
    /// <inheritdoc />
    public partial class registration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10af46ce-2464-4499-8721-250429ef754c", null, "Admin", "ADMIN" },
                    { "6d1621a4-b395-4d47-b8a2-ea2742ba97d7", null, "Special", "SPECIAL" },
                    { "77fd8cce-b406-45c3-aa1b-be94d6d736b7", null, "Inspector", "INSPECTOR" },
                    { "7dfe6143-6bff-48cf-b5db-215a1bef8297", null, "User", "USER" },
                    { "b35ce94b-92d8-4e21-8e1f-ce487a0e1259", null, "Instructor", "INSTRUCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10af46ce-2464-4499-8721-250429ef754c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d1621a4-b395-4d47-b8a2-ea2742ba97d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77fd8cce-b406-45c3-aa1b-be94d6d736b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dfe6143-6bff-48cf-b5db-215a1bef8297");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b35ce94b-92d8-4e21-8e1f-ce487a0e1259");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
