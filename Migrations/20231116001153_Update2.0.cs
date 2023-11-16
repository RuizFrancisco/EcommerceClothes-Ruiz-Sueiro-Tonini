using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceClothes.Migrations
{
    /// <inheritdoc />
    public partial class Update20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "LineOfOrderId", "Name", "Price" },
                values: new object[] { 2, "Campera negra", null, "Campera", 18000f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
