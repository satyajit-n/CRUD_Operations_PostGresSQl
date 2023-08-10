using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_Operations_PostGresSQl.Migrations
{
    /// <inheritdoc />
    public partial class minorchanges5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicantDate",
                table: "ApplicantsCreateEntries");

            migrationBuilder.RenameColumn(
                name: "ApplicantNumber",
                table: "ApplicantsCreateEntries",
                newName: "ApplicantMiddleName");

            migrationBuilder.RenameColumn(
                name: "ApplicantCustomerName",
                table: "ApplicantsCreateEntries",
                newName: "ApplicantUpdateBy");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantCreateBy",
                table: "ApplicantsCreateEntries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicantCreateDate",
                table: "ApplicantsCreateEntries",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicantFirstName",
                table: "ApplicantsCreateEntries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantLastName",
                table: "ApplicantsCreateEntries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicantUpdateDate",
                table: "ApplicantsCreateEntries",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LeadRefId",
                table: "ApplicantsCreateEntries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantsCreateEntries_LeadRefId",
                table: "ApplicantsCreateEntries",
                column: "LeadRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantsCreateEntries_Leads_LeadRefId",
                table: "ApplicantsCreateEntries",
                column: "LeadRefId",
                principalTable: "Leads",
                principalColumn: "LeadId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantsCreateEntries_Leads_LeadRefId",
                table: "ApplicantsCreateEntries");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantsCreateEntries_LeadRefId",
                table: "ApplicantsCreateEntries");

            migrationBuilder.DropColumn(
                name: "ApplicantCreateBy",
                table: "ApplicantsCreateEntries");

            migrationBuilder.DropColumn(
                name: "ApplicantCreateDate",
                table: "ApplicantsCreateEntries");

            migrationBuilder.DropColumn(
                name: "ApplicantFirstName",
                table: "ApplicantsCreateEntries");

            migrationBuilder.DropColumn(
                name: "ApplicantLastName",
                table: "ApplicantsCreateEntries");

            migrationBuilder.DropColumn(
                name: "ApplicantUpdateDate",
                table: "ApplicantsCreateEntries");

            migrationBuilder.DropColumn(
                name: "LeadRefId",
                table: "ApplicantsCreateEntries");

            migrationBuilder.RenameColumn(
                name: "ApplicantUpdateBy",
                table: "ApplicantsCreateEntries",
                newName: "ApplicantCustomerName");

            migrationBuilder.RenameColumn(
                name: "ApplicantMiddleName",
                table: "ApplicantsCreateEntries",
                newName: "ApplicantNumber");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ApplicantDate",
                table: "ApplicantsCreateEntries",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
