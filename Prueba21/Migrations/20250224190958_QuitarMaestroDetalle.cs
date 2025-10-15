using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba21.Migrations
{
    /// <inheritdoc />
    public partial class QuitarMaestroDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesHospedaje");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetallesHospedaje",
                columns: table => new
                {
                    DetalleHospedajeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HabitacionId = table.Column<int>(type: "int", nullable: true),
                    OrdenHospedajeId = table.Column<int>(type: "int", nullable: true),
                    PrecioHabitacion = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesHospedaje", x => x.DetalleHospedajeId);
                    table.ForeignKey(
                        name: "FK_DetallesHospedaje_Habitaciones_HabitacionId",
                        column: x => x.HabitacionId,
                        principalTable: "Habitaciones",
                        principalColumn: "HabitacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetallesHospedaje_OrdenesHospedaje_OrdenHospedajeId",
                        column: x => x.OrdenHospedajeId,
                        principalTable: "OrdenesHospedaje",
                        principalColumn: "OrdenHospedajeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesHospedaje_HabitacionId",
                table: "DetallesHospedaje",
                column: "HabitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesHospedaje_OrdenHospedajeId",
                table: "DetallesHospedaje",
                column: "OrdenHospedajeId");
        }
    }
}
