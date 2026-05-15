using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AkilliKomponentStokAsistani.Web.Models;
using AkilliKomponentStokAsistani.Web.Services;
using AkilliKomponentStokAsistani.Web.ViewModels;

namespace AkilliKomponentStokAsistani.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IComponentService _componentService;

    public HomeController(ILogger<HomeController> logger, IComponentService componentService)
    {
        _logger = logger;
        _componentService = componentService;
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> Index()
    {
        var components = await _componentService.GetAllAsync();
        var criticalStockItems = await _componentService.GetCriticalStockItemsAsync();

        var dashboardViewModel = new DashboardViewModel
        {
            TotalComponentCount = components.Count,
            CriticalStockCount = criticalStockItems.Count,
            TotalStockQuantity = components.Sum(c => c.StockQuantity),
            AveragePrice = components.Any() ? components.Average(c => c.Price) : 0,
            CriticalStockItems = criticalStockItems,
            LowestStockItems = components.OrderBy(c => c.StockQuantity).Take(5).ToList(),
            CategoryCounts = components.GroupBy(c => c.Category)
                                        .ToDictionary(g => g.Key, g => g.Count())
        };

        return View(dashboardViewModel);
    }
}
