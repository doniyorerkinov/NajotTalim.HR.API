using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NajotTalim.HR.DataAccess.Migrations
{
    public partial class SeedDefaultDataToMigrationDataAccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "id", "AddressLine1", "AddressLine2", "City", "Country", "PostalCode" },
                values: new object[] { 999, "asdas", "asdas", "asdas", "asdas", "asdas" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "id",
                keyValue: 999);
        }
    }
}
