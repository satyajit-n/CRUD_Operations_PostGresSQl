using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_Operations_PostGresSQl.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LeadFullName",
                table: "Leads",
                newName: "LeadMiddleName");

            migrationBuilder.AddColumn<string>(
                name: "LeadFirstName",
                table: "Leads",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LeadLastName",
                table: "Leads",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeadFirstName",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "LeadLastName",
                table: "Leads");

            migrationBuilder.RenameColumn(
                name: "LeadMiddleName",
                table: "Leads",
                newName: "LeadFullName");
        }
    }
}
