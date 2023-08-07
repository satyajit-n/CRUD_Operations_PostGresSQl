using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_Operations_PostGresSQl.Migrations
{
    /// <inheritdoc />
    public partial class LeadListTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    LeadId = table.Column<Guid>(type: "uuid", nullable: false),
                    LeadFullName = table.Column<string>(type: "text", nullable: false),
                    LeadContactNumber = table.Column<string>(type: "text", nullable: false),
                    LeadEmail = table.Column<string>(type: "text", nullable: false),
                    LeadLoanType = table.Column<string>(type: "text", nullable: false),
                    LeadProductType = table.Column<string>(type: "text", nullable: false),
                    LeadAssignedTo = table.Column<string>(type: "text", nullable: false),
                    LeadCreatedBy = table.Column<string>(type: "text", nullable: false),
                    LeadCreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LeadStatus = table.Column<string>(type: "text", nullable: false),
                    LeadMarkedForReview = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.LeadId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leads");
        }
    }
}
