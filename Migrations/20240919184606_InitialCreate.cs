using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyHouse.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agency_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agency_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agency_Status = table.Column<int>(type: "int", nullable: false),
                    NumCompany = table.Column<int>(type: "int", nullable: false),
                    Agency_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agency_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agency_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BenefitsServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenefitsName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitsServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Government_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contract_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgenciesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Agencies_AgenciesId",
                        column: x => x.AgenciesId,
                        principalTable: "Agencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uesr_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Type = table.Column<int>(type: "int", nullable: false),
                    Creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    AgenciesId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernmentsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Governments_GovernmentsId",
                        column: x => x.GovernmentsId,
                        principalTable: "Governments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Block_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitiesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocks_Cities_CitiesId",
                        column: x => x.CitiesId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Num_Rooms = table.Column<int>(type: "int", nullable: false),
                    Num_Bathrooms = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Under_constracting_Status = table.Column<int>(type: "int", nullable: false),
                    Furnishing = table.Column<bool>(type: "bit", nullable: false),
                    Added_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BlocksId = table.Column<int>(type: "int", nullable: true),
                    AgenciesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Agencies_AgenciesId",
                        column: x => x.AgenciesId,
                        principalTable: "Agencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Units_Blocks_BlocksId",
                        column: x => x.BlocksId,
                        principalTable: "Blocks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BenefitsServicesUnits",
                columns: table => new
                {
                    BenefitsServicesId = table.Column<int>(type: "int", nullable: false),
                    UnitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitsServicesUnits", x => new { x.BenefitsServicesId, x.UnitsId });
                    table.ForeignKey(
                        name: "FK_BenefitsServicesUnits_BenefitsServices_BenefitsServicesId",
                        column: x => x.BenefitsServicesId,
                        principalTable: "BenefitsServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BenefitsServicesUnits_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img_Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Interest",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    UnitsId = table.Column<int>(type: "int", nullable: false),
                    SuccessfulContact = table.Column<bool>(type: "bit", nullable: false),
                    Interest_AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interest", x => new { x.UsersId, x.UnitsId });
                    table.ForeignKey(
                        name: "FK_Interest_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interest_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BenefitsServicesUnits_UnitsId",
                table: "BenefitsServicesUnits",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_CitiesId",
                table: "Blocks",
                column: "CitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_GovernmentsId",
                table: "Cities",
                column: "GovernmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_AgenciesId",
                table: "Contracts",
                column: "AgenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UnitsId",
                table: "Images",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_Interest_UnitsId",
                table: "Interest",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_AgenciesId",
                table: "Units",
                column: "AgenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_BlocksId",
                table: "Units",
                column: "BlocksId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AgenciesId",
                table: "Users",
                column: "AgenciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenefitsServicesUnits");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Interest");

            migrationBuilder.DropTable(
                name: "BenefitsServices");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Governments");
        }
    }
}
