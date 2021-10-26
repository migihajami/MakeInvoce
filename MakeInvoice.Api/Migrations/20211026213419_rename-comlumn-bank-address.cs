using Microsoft.EntityFrameworkCore.Migrations;

namespace MakeInvoice.Api.Migrations
{
    public partial class renamecomlumnbankaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankInfos_Addresses_AddressID",
                table: "BankInfos");

            migrationBuilder.DropIndex(
                name: "IX_BankInfos_AddressID",
                table: "BankInfos");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "BankInfos");

            migrationBuilder.CreateIndex(
                name: "IX_BankInfos_BankAddressID",
                table: "BankInfos",
                column: "BankAddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_BankInfos_Addresses_BankAddressID",
                table: "BankInfos",
                column: "BankAddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankInfos_Addresses_BankAddressID",
                table: "BankInfos");

            migrationBuilder.DropIndex(
                name: "IX_BankInfos_BankAddressID",
                table: "BankInfos");

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "BankInfos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankInfos_AddressID",
                table: "BankInfos",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_BankInfos_Addresses_AddressID",
                table: "BankInfos",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
