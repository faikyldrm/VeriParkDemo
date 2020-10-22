using Microsoft.EntityFrameworkCore.Migrations;

namespace VeriParkDemo.Migrations
{
    public partial class NewVersionOfDb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BussinesDay",
                table: "Penalty",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Penalty",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PenaltyAmount",
                table: "Penalty",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "CountryBasedWeekend",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(nullable: true),
                    WeekendDay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryBasedWeekend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryBasedWeekend_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_CountryId",
                table: "Penalty",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryBasedWeekend_CountryId",
                table: "CountryBasedWeekend",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Penalty_Country_CountryId",
                table: "Penalty",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Penalty_Country_CountryId",
                table: "Penalty");

            migrationBuilder.DropTable(
                name: "CountryBasedWeekend");

            migrationBuilder.DropIndex(
                name: "IX_Penalty_CountryId",
                table: "Penalty");

            migrationBuilder.DropColumn(
                name: "BussinesDay",
                table: "Penalty");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Penalty");

            migrationBuilder.DropColumn(
                name: "PenaltyAmount",
                table: "Penalty");
        }
    }
}
