using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AkilliKomponentStokAsistani.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComponentItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComponentName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PackageType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    MinimumStockLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    DatasheetUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ComponentItems",
                columns: new[] { "Id", "Category", "ComponentName", "CreatedAt", "DatasheetUrl", "Description", "MinimumStockLevel", "PackageType", "Price", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Resistor", "1k Ohm Resistor", new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/1k-resistor", "Standard 1k Ohm resistor", 20, "Axial", 0.10m, 50, null },
                    { 2, "Capacitor", "10uF Capacitor", new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/10uf-capacitor", "Electrolytic capacitor", 15, "Radial", 0.15m, 10, null },
                    { 3, "Microcontroller", "STM32F103C8T6", new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/stm32f103", "ARM Cortex-M3 microcontroller", 10, "LQFP", 2.50m, 5, null },
                    { 4, "Transistor", "BC547 Transistor", new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/bc547", "NPN transistor", 50, "TO-92", 0.05m, 100, null },
                    { 5, "Voltage Regulator", "LM7805 Voltage Regulator", new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/lm7805", "5V voltage regulator", 10, "TO-220", 0.75m, 8, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentItems");
        }
    }
}
