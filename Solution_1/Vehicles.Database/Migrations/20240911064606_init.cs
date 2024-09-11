
#nullable disable

namespace Vehicles.Database.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Power = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

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
        }
    }
}
