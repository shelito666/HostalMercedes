using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Prueba21.Migrations
{
    /// <inheritdoc />
    public partial class AñadioDatosEnFormaDePagoPersonalYHabitacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FormasDePago",
                columns: new[] { "FormaDePagoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Efectivo" },
                    { 2, "Tarjeta de Crédito" },
                    { 3, "Tarjeta de Débito" },
                    { 4, "Transferencia Bancaria" }
                });

            migrationBuilder.InsertData(
                table: "Habitaciones",
                columns: new[] { "HabitacionId", "Estado", "Numero", "Precio", "Tipo" },
                values: new object[,]
                {
                    { 1, 0, "101", 100m, "Sencilla" },
                    { 2, 0, "102", 150m, "Doble" },
                    { 3, 0, "103", 200m, "Triple" },
                    { 4, 0, "104", 300m, "Suite" },
                    { 5, 0, "105", 500m, "Suite Presidencial" },
                    { 6, 0, "106", 100m, "Sencilla" },
                    { 7, 0, "107", 150m, "Doble" },
                    { 8, 0, "108", 200m, "Triple" },
                    { 9, 0, "109", 300m, "Suite" },
                    { 10, 0, "110", 500m, "Suite Presidencial" }
                });

            migrationBuilder.InsertData(
                table: "Personal",
                columns: new[] { "PersonalId", "Contrasenia", "Email", "Nombre", "Rol" },
                values: new object[] { 1, "admin", "admin@gmail.com", "Administrador", "Administrador" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FormasDePago",
                keyColumn: "FormaDePagoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FormasDePago",
                keyColumn: "FormaDePagoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FormasDePago",
                keyColumn: "FormaDePagoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FormasDePago",
                keyColumn: "FormaDePagoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "HabitacionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "HabitacionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "HabitacionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "HabitacionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "HabitacionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "HabitacionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "HabitacionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "HabitacionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "HabitacionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "HabitacionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "PersonalId",
                keyValue: 1);
        }
    }
}
