using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicles.Database.Migrations
{
    /// <inheritdoc />
    public partial class init_2024_09_25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormOfId",
                table: "Vehicle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FormOfId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
