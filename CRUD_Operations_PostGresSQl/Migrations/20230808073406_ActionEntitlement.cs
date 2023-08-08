using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRUD_Operations_PostGresSQl.Migrations
{
    /// <inheritdoc />
    public partial class ActionEntitlement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "ActionId",
                table: "EntitlementTables",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActionTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActionName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ActionTable",
                columns: new[] { "Id", "ActionName" },
                values: new object[,]
                {
                    { 400, "View" },
                    { 401, "Add" },
                    { 402, "Update" },
                    { 403, "Delete" },
                    { 404, "Review" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "MenuName" },
                values: new object[,]
                {
                    { 101, "Applicants" },
                    { 102, "Legal Verification" },
                    { 103, "Setting" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Role" },
                values: new object[,]
                {
                    { 200, "Admin" },
                    { 201, "Manager" }
                });

            migrationBuilder.InsertData(
                table: "EntitlementTables",
                columns: new[] { "Id", "ActionId", "MenuRefId", "RoleRefId" },
                values: new object[,]
                {
                    { 301, 400, 100, 200 },
                    { 302, 401, 100, 200 },
                    { 303, 402, 100, 200 },
                    { 304, 403, 100, 200 },
                    { 305, 404, 100, 200 },
                    { 306, 400, 101, 200 },
                    { 307, 401, 101, 200 },
                    { 308, 402, 101, 200 },
                    { 309, 403, 101, 200 },
                    { 310, 404, 101, 200 },
                    { 311, 400, 102, 200 },
                    { 312, 401, 102, 200 },
                    { 313, 404, 102, 200 },
                    { 314, 400, 103, 200 },
                    { 315, 400, 103, 201 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntitlementTables_ActionId",
                table: "EntitlementTables",
                column: "ActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntitlementTables_ActionTable_ActionId",
                table: "EntitlementTables",
                column: "ActionId",
                principalTable: "ActionTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntitlementTables_ActionTable_ActionId",
                table: "EntitlementTables");

            migrationBuilder.DropTable(
                name: "ActionTable");

            migrationBuilder.DropIndex(
                name: "IX_EntitlementTables_ActionId",
                table: "EntitlementTables");

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "EntitlementTables",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DropColumn(
                name: "ActionId",
                table: "EntitlementTables");

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "MenuName" },
                values: new object[,]
                {
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
        }
    }
}
