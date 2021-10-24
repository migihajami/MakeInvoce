using Microsoft.EntityFrameworkCore.Migrations;

namespace MakeInvoice.Api.Migrations
{
    public partial class add_owner_anywhere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Invoices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "InvoiceItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "BankInfos",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OwnerID",
                table: "Invoices",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_OwnerID",
                table: "InvoiceItems",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_BankInfos_OwnerID",
                table: "BankInfos",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_BankInfos_AspNetUsers_OwnerID",
                table: "BankInfos",
                column: "OwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_AspNetUsers_OwnerID",
                table: "InvoiceItems",
                column: "OwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_OwnerID",
                table: "Invoices",
                column: "OwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankInfos_AspNetUsers_OwnerID",
                table: "BankInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_AspNetUsers_OwnerID",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_OwnerID",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_OwnerID",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_OwnerID",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_BankInfos_OwnerID",
                table: "BankInfos");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "BankInfos");
        }
    }
}
