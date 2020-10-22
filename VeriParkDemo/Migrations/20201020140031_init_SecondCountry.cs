using Microsoft.EntityFrameworkCore.Migrations;

namespace VeriParkDemo.Migrations
{
    public partial class init_SecondCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "CountryName", "CurrencyCode", "FirstWeekendDay", "SecondWeekendDay" },
                values: new object[] { 2, "USA", "USD", 0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
