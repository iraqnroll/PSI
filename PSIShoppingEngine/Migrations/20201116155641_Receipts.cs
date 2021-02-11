using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSIShoppingEngine.Migrations
{
    public partial class Receipts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "ItemPrices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Shop = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPrices_ReceiptId",
                table: "ItemPrices",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPrices_Receipts_ReceiptId",
                table: "ItemPrices",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPrices_Receipts_ReceiptId",
                table: "ItemPrices");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_ItemPrices_ReceiptId",
                table: "ItemPrices");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "ItemPrices");
        }
    }
}
