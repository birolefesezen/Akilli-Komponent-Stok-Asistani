using AkilliKomponentStokAsistani.Web.Data;
using AkilliKomponentStokAsistani.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace AkilliKomponentStokAsistani.Web.Repositories
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly AppDbContext _context;

        public ComponentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ComponentItem>> GetAllAsync()
        {
            return await _context.ComponentItems
                .OrderBy(c => c.ComponentName)
                .ToListAsync();
        }

        public async Task<ComponentItem?> GetByIdAsync(int id)
        {
            return await _context.ComponentItems.FindAsync(id);
        }

        public async Task<List<ComponentItem>> GetCriticalStockItemsAsync()
        {
            return await _context.ComponentItems
                .Where(c => c.StockQuantity <= c.MinimumStockLevel)
                .ToListAsync();
        }

        public async Task AddAsync(ComponentItem componentItem)
        {
            await _context.ComponentItems.AddAsync(componentItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ComponentItem componentItem)
        {
            _context.ComponentItems.Update(componentItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var componentItem = await GetByIdAsync(id);
            if (componentItem != null)
            {
                _context.ComponentItems.Remove(componentItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.ComponentItems.AnyAsync(c => c.Id == id);
        }
    }
}