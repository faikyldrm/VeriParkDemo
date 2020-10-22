using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VeriParkDemo.Migrations
{
    public partial class NewVersionOfDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryBasedHoliday",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(nullable: true),
                    HolidayDate = table.Column<DateTime>(nullable: false),
                    HolidayType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryBasedHoliday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryBasedHoliday_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryBasedHoliday_CountryId",
                table: "CountryBasedHoliday",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryBasedHoliday");
        }
    }
}
