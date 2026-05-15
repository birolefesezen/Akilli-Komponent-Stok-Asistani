using System;
using Microsoft.EntityFrameworkCore;
using AkilliKomponentStokAsistani.Web.Models;

namespace AkilliKomponentStokAsistani.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ComponentItem> ComponentItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComponentItem>().HasData(
                new ComponentItem
                {
                    Id = 1,
                    ComponentName = "1k Ohm Resistor",
                    Category = "Resistor",
                    PackageType = "Axial",
                    Price = 0.10m,
                    StockQuantity = 50,
                    MinimumStockLevel = 20,
                    Description = "Standard 1k Ohm resistor",
                    DatasheetUrl = "http://example.com/1k-resistor",
                    CreatedAt = new DateTime(2026, 5, 15)
                },
                new ComponentItem
                {
                    Id = 2,
                    ComponentName = "10uF Capacitor",
                    Category = "Capacitor",
                    PackageType = "Radial",
                    Price = 0.15m,
                    StockQuantity = 10,
                    MinimumStockLevel = 15,
                    Description = "Electrolytic capacitor",
                    DatasheetUrl = "http://example.com/10uf-capacitor",
                    CreatedAt = new DateTime(2026, 5, 15)
                },
                new ComponentItem
                {
                    Id = 3,
                    ComponentName = "STM32F103C8T6",
                    Category = "Microcontroller",
                    PackageType = "LQFP",
                    Price = 2.50m,
                    StockQuantity = 5,
                    MinimumStockLevel = 10,
                    Description = "ARM Cortex-M3 microcontroller",
                    DatasheetUrl = "http://example.com/stm32f103",
                    CreatedAt = new DateTime(2026, 5, 15)
                },
                new ComponentItem
                {
                    Id = 4,
                    ComponentName = "BC547 Transistor",
                    Category = "Transistor",
                    PackageType = "TO-92",
                    Price = 0.05m,
                    StockQuantity = 100,
                    MinimumStockLevel = 50,
                    Description = "NPN transistor",
                    DatasheetUrl = "http://example.com/bc547",
                    CreatedAt = new DateTime(2026, 5, 15)
                },
                new ComponentItem
                {
                    Id = 5,
                    ComponentName = "LM7805 Voltage Regulator",
                    Category = "Voltage Regulator",
                    PackageType = "TO-220",
                    Price = 0.75m,
                    StockQuantity = 8,
                    MinimumStockLevel = 10,
                    Description = "5V voltage regulator",
                    DatasheetUrl = "http://example.com/lm7805",
                    CreatedAt = new DateTime(2026, 5, 15)
                }
            );
        }
    }
}