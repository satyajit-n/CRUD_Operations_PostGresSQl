using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRUD_Operations_PostGresSQl.Migrations
{
    /// <inheritdoc />
    public partial class newConnectionSetup : Migration
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

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MenuName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntitlementTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MenuRefId = table.Column<int>(type: "integer", nullable: false),
                    RoleRefId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntitlementTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntitlementTables_Menus_MenuRefId",
                        column: x => x.MenuRefId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntitlementTables_Roles_RoleRefId",
                        column: x => x.RoleRefId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "MenuName" },
                values: new object[,]
                {
                    { 100, "Leads" },
                    { 200, "Applicants" },
                    { 300, "Legal Verification" },
                    { 400, "Setting" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Role" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Manager" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_EntitlementTables_MenuRefId",
                table: "EntitlementTables",
                column: "MenuRefId");

            migrationBuilder.CreateIndex(
                name: "IX_EntitlementTables_RoleRefId",
                table: "EntitlementTables",
                column: "RoleRefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantsCreateEntries");

            migrationBuilder.DropTable(
                name: "EntitlementTables");

            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
