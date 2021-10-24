using Microsoft.EntityFrameworkCore.Migrations;

namespace MakeInvoice.Api.Migrations
{
    public partial class address_fk_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Addresses_OwnerID",
                table: "Addresses",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_OwnerID",
                table: "Addresses",
                column: "OwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_OwnerID",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_OwnerID",
                table: "Addresses");
        }
    }
}
