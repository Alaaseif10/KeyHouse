using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyHouse.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agency_Email",
                table: "Agencies");

            migrationBuilder.RenameColumn(
                name: "Agency_Phone",
                table: "Agencies",
                newName: "AgencyContactPhone");

            migrationBuilder.RenameColumn(
                name: "Agency_Password",
                table: "Agencies",
                newName: "AgencyContactEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AgencyContactPhone",
                table: "Agencies",
                newName: "Agency_Phone");

            migrationBuilder.RenameColumn(
                name: "AgencyContactEmail",
                table: "Agencies",
                newName: "Agency_Password");

            migrationBuilder.AddColumn<string>(
                name: "Agency_Email",
                table: "Agencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
