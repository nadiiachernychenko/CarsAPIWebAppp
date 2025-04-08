using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsAPIWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarSharingZones",
                columns: table => new
                {
                    CSZ_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CSZ_TOWN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarSharingZones", x => x.CSZ_ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CS_FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CS_LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CS_PHONE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CS_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CS_ID);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    MD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MD_MODEL_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MD_NUM_OF_SEATS = table.Column<int>(type: "int", nullable: false),
                    MD_IS_AUTOMATIC = table.Column<bool>(type: "bit", nullable: false),
                    MD_ENGINE_VOLUME = table.Column<double>(type: "float", nullable: false),
                    MD_BRAND = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MD_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.MD_ID);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CR_PRODUCE_YEAR = table.Column<int>(type: "int", nullable: false),
                    CR_MODEL_ID = table.Column<int>(type: "int", nullable: false),
                    CR_COLOR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CR_ID);
                    table.ForeignKey(
                        name: "FK_Cars_Models_CR_MODEL_ID",
                        column: x => x.CR_MODEL_ID,
                        principalTable: "Models",
                        principalColumn: "MD_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    RN_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RN_CAR_ID = table.Column<int>(type: "int", nullable: false),
                    RN_START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RN_FINISH_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RN_COST_PER_DAY = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RN_CS_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.RN_ID);
                    table.ForeignKey(
                        name: "FK_Rents_Cars_RN_CAR_ID",
                        column: x => x.RN_CAR_ID,
                        principalTable: "Cars",
                        principalColumn: "CR_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Customers_RN_CS_ID",
                        column: x => x.RN_CS_ID,
                        principalTable: "Customers",
                        principalColumn: "CS_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CR_MODEL_ID",
                table: "Cars",
                column: "CR_MODEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_RN_CAR_ID",
                table: "Rents",
                column: "RN_CAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_RN_CS_ID",
                table: "Rents",
                column: "RN_CS_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarSharingZones");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
