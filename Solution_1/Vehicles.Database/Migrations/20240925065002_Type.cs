using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vehicles.Database.Migrations
{
    /// <inheritdoc />
    public partial class Type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TypeId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Type",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Bus" },
                    { 2L, "Truck" },
                    { 3L, "Motorcycle" },
                    { 4L, "Car" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_TypeId",
                table: "Vehicle",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Type_Name",
                table: "Type",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Type_TypeId",
                table: "Vehicle",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Type_TypeId",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_TypeId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Vehicle");
        }
    }
}
