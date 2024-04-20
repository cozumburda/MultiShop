using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Discount.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rate",
                table: "Coupons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rate",
                table: "Coupons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
