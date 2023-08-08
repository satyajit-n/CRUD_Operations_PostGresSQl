using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_Operations_PostGresSQl.Migrations
{
    /// <inheritdoc />
    public partial class minorchanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 102,
                column: "MenuName",
                value: "Legal Verification");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 102,
                column: "MenuName",
                value: "LegalVerification");
        }
    }
}
