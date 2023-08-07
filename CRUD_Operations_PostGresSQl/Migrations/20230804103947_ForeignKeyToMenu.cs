using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CRUD_Operations_PostGresSQl.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyToMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "EntitlementTables");
        }
    }
}
