using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FruitsProducer.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProducerCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducerCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fruits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProducerCountryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fruits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fruits_ProducerCountries_ProducerCountryId",
                        column: x => x.ProducerCountryId,
                        principalTable: "ProducerCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProducerCountries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "España" },
                    { 2, "Cuba" },
                    { 3, "EEUU" },
                    { 4, "India" }
                });

            migrationBuilder.InsertData(
                table: "Fruits",
                columns: new[] { "Id", "Name", "Price", "ProducerCountryId" },
                values: new object[,]
                {
                    { 1, "Banana", 3.99m, 1 },
                    { 2, "Banana", 2.99m, 4 },
                    { 3, "Manzana", 2.99m, 1 },
                    { 4, "Manzana", 2.99m, 3 },
                    { 5, "Aguacate", 0.99m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fruits_ProducerCountryId",
                table: "Fruits",
                column: "ProducerCountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fruits");

            migrationBuilder.DropTable(
                name: "ProducerCountries");
        }
    }
}
