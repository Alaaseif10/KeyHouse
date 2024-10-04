using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyHouse.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgencyContactEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AgencyContactPhone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Agency_Description",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "logo",
                table: "AspNetUsers",
                newName: "AgencyName");

            migrationBuilder.RenameColumn(
                name: "Agency_Status",
                table: "AspNetUsers",
                newName: "AgencyStatus");

            migrationBuilder.RenameColumn(
                name: "Agency_Name",
                table: "AspNetUsers",
                newName: "AgencyDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AgencyStatus",
                table: "AspNetUsers",
                newName: "Agency_Status");

            migrationBuilder.RenameColumn(
                name: "AgencyName",
                table: "AspNetUsers",
                newName: "logo");

            migrationBuilder.RenameColumn(
                name: "AgencyDescription",
                table: "AspNetUsers",
                newName: "Agency_Name");

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
        }
    }
}
