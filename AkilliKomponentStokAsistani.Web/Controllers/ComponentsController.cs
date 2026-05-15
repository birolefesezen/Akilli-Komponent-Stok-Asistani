using AkilliKomponentStokAsistani.Web.Models;
using AkilliKomponentStokAsistani.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AkilliKomponentStokAsistani.Web.Controllers
{
    public class ComponentsController : Controller
    {
        private readonly IComponentService _componentService;

        public ComponentsController(IComponentService componentService)
        {
            _componentService = componentService;
        }

        public async Task<IActionResult> Index()
        {
            var components = await _componentService.GetAllAsync();
            return View(components);
        }

        public async Task<IActionResult> Details(int id)
        {
            var component = await _componentService.GetByIdAsync(id);
            if (component == null)
            {
                return NotFound();
            }
            return View(component);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ComponentItem componentItem)
        {
            if (ModelState.IsValid)
            {
                await _componentService.AddAsync(componentItem);
                return RedirectToAction(nameof(Index));
            }
            return View(componentItem);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var component = await _componentService.GetByIdAsync(id);
            if (component == null)
            {
                return NotFound();
            }
            return View(component);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ComponentItem componentItem)
        {
            if (id != componentItem.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _componentService.UpdateAsync(componentItem);
                return RedirectToAction(nameof(Index));
            }
            return View(componentItem);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var component = await _componentService.GetByIdAsync(id);
            if (component == null)
            {
                return NotFound();
            }
            return View(component);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _componentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CriticalStock()
        {
            var criticalComponents = await _componentService.GetCriticalStockItemsAsync();
            return View(criticalComponents);
        }
    }
}