using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyHouse.Migrations
{
    /// <inheritdoc />
    public partial class AddProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Agencies_AgenciesId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_AgenciesId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "AgenciesId",
                table: "Units");

            migrationBuilder.AlterColumn<int>(
                name: "Unit_Title",
                table: "Units",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Under_constracting_Status",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Num_Rooms",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Num_Bathrooms",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Type_Rent",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type_Unit",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AgenciesUnits",
                columns: table => new
                {
                    AgenciesId = table.Column<int>(type: "int", nullable: false),
                    UnitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgenciesUnits", x => new { x.AgenciesId, x.UnitsId });
                    table.ForeignKey(
                        name: "FK_AgenciesUnits_Agencies_AgenciesId",
                        column: x => x.AgenciesId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgenciesUnits_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgenciesUnits_UnitsId",
                table: "AgenciesUnits",
                column: "UnitsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgenciesUnits");

            migrationBuilder.DropColumn(
                name: "Type_Rent",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Type_Unit",
                table: "Units");

            migrationBuilder.AlterColumn<string>(
                name: "Unit_Title",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Under_constracting_Status",
                table: "Units",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Num_Rooms",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Num_Bathrooms",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgenciesId",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_AgenciesId",
                table: "Units",
                column: "AgenciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Agencies_AgenciesId",
                table: "Units",
                column: "AgenciesId",
                principalTable: "Agencies",
                principalColumn: "Id");
        }
    }
}
