using Microsoft.EntityFrameworkCore.Migrations;

namespace VeriParkDemo.Migrations
{
    public partial class NewVersionOfDb5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PenaltyAmount",
                table: "Penalty",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PenaltyAmount",
                table: "Penalty",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
