using Microsoft.EntityFrameworkCore.Migrations;

namespace PSIShoppingEngine.Migrations
{
    public partial class ChangedPriceToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "ItemPrices",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "ItemPrices",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
