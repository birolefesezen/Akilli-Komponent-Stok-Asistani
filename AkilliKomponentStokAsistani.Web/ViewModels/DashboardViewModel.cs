using AkilliKomponentStokAsistani.Web.Models;

namespace AkilliKomponentStokAsistani.Web.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalComponentCount { get; set; }
        public int CriticalStockCount { get; set; }
        public int TotalStockQuantity { get; set; }
        public decimal AveragePrice { get; set; }
        public List<ComponentItem> CriticalStockItems { get; set; } = new List<ComponentItem>();
        public List<ComponentItem> LowestStockItems { get; set; } = new List<ComponentItem>();
        public Dictionary<string, int> CategoryCounts { get; set; } = new Dictionary<string, int>();
    }
}