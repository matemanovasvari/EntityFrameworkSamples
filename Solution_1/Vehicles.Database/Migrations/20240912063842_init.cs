using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vehicles.Database.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicencePlate = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    ChassisNumber = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    EngineNumber = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    NumberOfDoors = table.Column<long>(type: "bigint", nullable: false),
                    Weight = table.Column<long>(type: "bigint", nullable: false),
                    Power = table.Column<long>(type: "bigint", nullable: false),
                    ColorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1L, "ffffff", "white" },
                    { 2L, "000000", "black" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Color_Name_Code",
                table: "Color",
                columns: new[] { "Name", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ColorId",
                table: "Vehicle",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_LicencePlate",
                table: "Vehicle",
                column: "LicencePlate",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Color");
        }
    }
}
