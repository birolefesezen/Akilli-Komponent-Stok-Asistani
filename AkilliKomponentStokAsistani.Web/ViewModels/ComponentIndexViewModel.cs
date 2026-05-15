using AkilliKomponentStokAsistani.Web.Models;
using System.Collections.Generic;

namespace AkilliKomponentStokAsistani.Web.ViewModels
{
    public class ComponentIndexViewModel
    {
        public List<ComponentItem> Components { get; set; } = new List<ComponentItem>();
        public string? SearchTerm { get; set; }
        public string? SelectedCategory { get; set; }
        public bool ShowOnlyCritical { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
    }
}