using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRUD_Operations_PostGresSQl.Migrations
{
    /// <inheritdoc />
    public partial class insertToEntitlement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EntitlementTables",
                columns: new[] { "Id", "MenuRefId", "RoleRefId" },
                values: new object[,]
                {
                    { 101, 100, 1 },
                    { 102, 200, 1 },
                    { 103, 300, 1 },
                    { 104, 400, 1 },
                    { 105, 300, 2 },
                    { 106, 400, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 106);
        }
    }
}
