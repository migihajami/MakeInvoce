using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MakeInvoice.Api.Migrations
{
    public partial class addcontractors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Addresses_LegalAddressID",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Addresses_PostalAddressID",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_OwnerID",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_PostalAddressID",
                table: "Company",
                newName: "IX_Company_PostalAddressID");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_OwnerID",
                table: "Company",
                newName: "IX_Company_OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_LegalAddressID",
                table: "Company",
                newName: "IX_Company_LegalAddressID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Contractor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contractor_Company_ID",
                        column: x => x.ID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Addresses_LegalAddressID",
                table: "Company",
                column: "LegalAddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Addresses_PostalAddressID",
                table: "Company",
                column: "PostalAddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_AspNetUsers_OwnerID",
                table: "Company",
                column: "OwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Addresses_LegalAddressID",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Addresses_PostalAddressID",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_AspNetUsers_OwnerID",
                table: "Company");

            migrationBuilder.DropTable(
                name: "Contractor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_Company_PostalAddressID",
                table: "Companies",
                newName: "IX_Companies_PostalAddressID");

            migrationBuilder.RenameIndex(
                name: "IX_Company_OwnerID",
                table: "Companies",
                newName: "IX_Companies_OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Company_LegalAddressID",
                table: "Companies",
                newName: "IX_Companies_LegalAddressID");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Companies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Companies",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Addresses_LegalAddressID",
                table: "Companies",
                column: "LegalAddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Addresses_PostalAddressID",
                table: "Companies",
                column: "PostalAddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_OwnerID",
                table: "Companies",
                column: "OwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
