using Microsoft.EntityFrameworkCore.Migrations;

namespace VeriParkDemo.Migrations
{
    public partial class NewVersionOfDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "CountryName", "CurrencyCode" },
                values: new object[] { 1, "Türkiye", "TRY" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "CountryName", "CurrencyCode" },
                values: new object[] { 2, "USA", "USD" });
        }
    }
}
