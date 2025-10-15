using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba21.Migrations
{
    /// <inheritdoc />
    public partial class OrdeConserjeria21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "OrdenesConserjeria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "OrdenesConserjeria");
        }
    }
}
