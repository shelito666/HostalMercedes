using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba21.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionDeCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contrasenia",
                table: "Personal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Personal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Personal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contrasenia",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contrasenia",
                table: "Personal");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Personal");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Personal");

            migrationBuilder.DropColumn(
                name: "Contrasenia",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Clientes");
        }
    }
}
