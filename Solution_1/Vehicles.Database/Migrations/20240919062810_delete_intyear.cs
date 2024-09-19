using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicles.Database.Migrations
{
    /// <inheritdoc />
    public partial class delete_intyear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntrouctionYear",
                table: "Model");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IntrouctionYear",
                table: "Model",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
