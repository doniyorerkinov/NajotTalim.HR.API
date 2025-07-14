using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NajotTalim.HR.DataAccess.Migrations
{
    public partial class AddedAddressIdToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Addressid",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Addressid",
                table: "Employees",
                column: "Addressid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Addresses_Addressid",
                table: "Employees",
                column: "Addressid",
                principalTable: "Addresses",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Addresses_Addressid",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Addressid",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Addressid",
                table: "Employees");
        }
    }
}
