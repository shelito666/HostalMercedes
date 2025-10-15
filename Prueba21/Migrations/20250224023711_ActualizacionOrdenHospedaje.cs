using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba21.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionOrdenHospedaje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "OrdenesHospedaje",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaFin",
                table: "OrdenesConserjeria",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "OrdenesHospedaje");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaFin",
                table: "OrdenesConserjeria",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
