using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP_Principal_G4.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedRazasDeGato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Razas",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 3, "Gato persa" },
                    { 4, "Gato siamés" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
