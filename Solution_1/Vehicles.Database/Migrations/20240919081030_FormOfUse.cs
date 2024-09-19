using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vehicles.Database.Migrations
{
    /// <inheritdoc />
    public partial class FormOfUse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FormOfId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FormOfUseId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "FormOfUse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormOfUse", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FormOfUse",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Taxi" },
                    { 2L, "Transport" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_FormOfUseId",
                table: "Vehicle",
                column: "FormOfUseId");

            migrationBuilder.CreateIndex(
                name: "IX_FormOfUse_Name",
                table: "FormOfUse",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_FormOfUse_FormOfUseId",
                table: "Vehicle",
                column: "FormOfUseId",
                principalTable: "FormOfUse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_FormOfUse_FormOfUseId",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "FormOfUse");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_FormOfUseId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "FormOfId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "FormOfUseId",
                table: "Vehicle");
        }
    }
}
