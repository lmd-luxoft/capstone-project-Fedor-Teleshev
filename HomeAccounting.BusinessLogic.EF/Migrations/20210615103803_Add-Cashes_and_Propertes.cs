using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeAccounting.BusinessLogic.EF.Migrations
{
    public partial class AddCashes_and_Propertes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "PricesChanges",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cashes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CoinNumber = table.Column<int>(type: "int", nullable: false),
                    CashNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cashes_Accounts_Id",
                        column: x => x.Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Propertes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propertes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propertes_Accounts_Id",
                        column: x => x.Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PricesChanges_PropertyId",
                table: "PricesChanges",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PricesChanges_Propertes_PropertyId",
                table: "PricesChanges",
                column: "PropertyId",
                principalTable: "Propertes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PricesChanges_Propertes_PropertyId",
                table: "PricesChanges");

            migrationBuilder.DropTable(
                name: "Cashes");

            migrationBuilder.DropTable(
                name: "Propertes");

            migrationBuilder.DropIndex(
                name: "IX_PricesChanges_PropertyId",
                table: "PricesChanges");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "PricesChanges");
        }
    }
}
