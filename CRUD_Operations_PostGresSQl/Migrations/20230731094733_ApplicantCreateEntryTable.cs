using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_Operations_PostGresSQl.Migrations
{
    /// <inheritdoc />
    public partial class ApplicantCreateEntryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantsCreateEntries",
                columns: table => new
                {
                    ApplicantID = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicantNumber = table.Column<string>(type: "text", nullable: false),
                    ApplicantDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ApllicantBranch = table.Column<string>(type: "text", nullable: false),
                    ApplicantCustomerName = table.Column<string>(type: "text", nullable: true),
                    ApplicantApplicationType = table.Column<string>(type: "text", nullable: false),
                    ApplicantProductType = table.Column<string>(type: "text", nullable: false),
                    ApplicantCategory = table.Column<string>(type: "text", nullable: false),
                    ApplicantPanCard = table.Column<string>(type: "text", nullable: false),
                    ApplicantStatus = table.Column<string>(type: "text", nullable: false),
                    ApplicantLevel = table.Column<string>(type: "text", nullable: true),
                    ApplicantMarkedForReview = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantsCreateEntries", x => x.ApplicantID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantsCreateEntries");
        }
    }
}
