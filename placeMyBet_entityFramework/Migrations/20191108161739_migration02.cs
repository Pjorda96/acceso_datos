using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace placeMyBet.Migrations
{
    public partial class migration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Partidos",
                columns: new[] { "Id", "Hora", "Local", "Visitante" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 10, 19, 19, 28, 49, 0, DateTimeKind.Unspecified), "Valencia", "Barsa" },
                    { 2, new DateTime(2019, 10, 19, 19, 28, 49, 0, DateTimeKind.Unspecified), "Madrid", "Leganes" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Active", "Apellidos", "BirtdhDate", "DNI", "Email", "Nombre", "Saldo" },
                values: new object[,]
                {
                    { 1, false, "Jorda Garcia", new DateTime(2019, 10, 19, 19, 28, 49, 0, DateTimeKind.Unspecified), "12345678B", "pjorda96@gmail.com", "Pablo", 0.0 },
                    { 2, false, "Tio Uge", new DateTime(2019, 10, 19, 19, 28, 49, 0, DateTimeKind.Unspecified), "87654321A", "halleck@gmail.com", "Eugenio", 100.0 }
                });

            migrationBuilder.InsertData(
                table: "DatosBancos",
                columns: new[] { "Id", "Alias", "Cvv", "ExpTime", "Numero", "Tipo", "Titular", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "Tarjeta Black", 123, new DateTime(2019, 10, 19, 19, 28, 49, 0, DateTimeKind.Unspecified), "126443653", 1, "Pablo Jorda Garcia", 1 },
                    { 2, "Visa Super Platino", 321, new DateTime(2019, 10, 19, 19, 28, 49, 0, DateTimeKind.Unspecified), "1266443653", 1, "Eugenio", 2 }
                });

            migrationBuilder.InsertData(
                table: "Mercados",
                columns: new[] { "Id", "COver", "CUnder", "PartidoId", "Tipo" },
                values: new object[,]
                {
                    { 1, 3.0, 1.2, 1, 1 },
                    { 2, 2.5, 1.5, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "Id", "Cuota", "Fecha", "Importe", "MercadoId", "TipoApuesta", "UsuarioId" },
                values: new object[] { 1, 1.2, new DateTime(2019, 10, 19, 19, 28, 49, 0, DateTimeKind.Unspecified), 10.0, 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "Id", "Cuota", "Fecha", "Importe", "MercadoId", "TipoApuesta", "UsuarioId" },
                values: new object[] { 2, 1.5, new DateTime(2019, 10, 19, 19, 28, 49, 0, DateTimeKind.Unspecified), 100.0, 2, 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DatosBancos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DatosBancos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mercados",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mercados",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Partidos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Partidos",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
