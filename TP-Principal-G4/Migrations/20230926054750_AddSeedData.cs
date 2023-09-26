using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP_Principal_G4.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Razas",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "San bernardo" },
                    { 2, "Labrador retriever" }
                });

            migrationBuilder.InsertData(
                table: "Refugios",
                columns: new[] { "Id", "ApellidoDelResponsable", "Nombre", "NombreDelResponsable", "RazonSocial" },
                values: new object[] { 1, "Pérez", "Santuario animal", "Jorge", "Santuario animal S.A." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Refugios",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
