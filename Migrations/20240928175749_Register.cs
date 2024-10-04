using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyHouse.Migrations
{
    /// <inheritdoc />
    public partial class Register : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Agencies_AgenciesId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Interest_Users_UsersId",
                table: "Interest");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Agencies_AgenciesId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.AlterColumn<string>(
                name: "AgenciesId",
                table: "Units",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId1",
                table: "Interest",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "AgenciesId",
                table: "Contracts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgenciesId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgencyContactEmail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgencyContactPhone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Agency_Description",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Agency_Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Agency_Status",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Creation_date",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumCompany",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_Type",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "logo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Interest_UsersId1",
                table: "Interest",
                column: "UsersId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AgenciesId",
                table: "AspNetUsers",
                column: "AgenciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_AgenciesId",
                table: "AspNetUsers",
                column: "AgenciesId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_AspNetUsers_AgenciesId",
                table: "Contracts",
                column: "AgenciesId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interest_AspNetUsers_UsersId1",
                table: "Interest",
                column: "UsersId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_AspNetUsers_AgenciesId",
                table: "Units",
                column: "AgenciesId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_AgenciesId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_AspNetUsers_AgenciesId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Interest_AspNetUsers_UsersId1",
                table: "Interest");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_AspNetUsers_AgenciesId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Interest_UsersId1",
                table: "Interest");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AgenciesId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UsersId1",
                table: "Interest");

            migrationBuilder.DropColumn(
                name: "AgenciesId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AgencyContactEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AgencyContactPhone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Agency_Description",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Agency_Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Agency_Status",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Creation_date",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NumCompany",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "User_Type",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "logo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "status",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "AgenciesId",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgenciesId",
                table: "Contracts",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgencyContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agency_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agency_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agency_Status = table.Column<int>(type: "int", nullable: false),
                    NumCompany = table.Column<int>(type: "int", nullable: false),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgenciesId = table.Column<int>(type: "int", nullable: true),
                    Creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uesr_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Type = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Agencies_AgenciesId",
                        column: x => x.AgenciesId,
                        principalTable: "Agencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AgenciesId",
                table: "Users",
                column: "AgenciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Agencies_AgenciesId",
                table: "Contracts",
                column: "AgenciesId",
                principalTable: "Agencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interest_Users_UsersId",
                table: "Interest",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Agencies_AgenciesId",
                table: "Units",
                column: "AgenciesId",
                principalTable: "Agencies",
                principalColumn: "Id");
        }
    }
}
