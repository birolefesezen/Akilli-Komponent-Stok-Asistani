using System;
using System.ComponentModel.DataAnnotations;

namespace AkilliKomponentStokAsistani.Web.Models
{
    public class ComponentItem
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ComponentName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        [MaxLength(50)]
        public string PackageType { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        [Range(0, int.MaxValue)]
        public int MinimumStockLevel { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Url]
        public string DatasheetUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public bool IsCriticalStock => StockQuantity <= MinimumStockLevel;
    }
}