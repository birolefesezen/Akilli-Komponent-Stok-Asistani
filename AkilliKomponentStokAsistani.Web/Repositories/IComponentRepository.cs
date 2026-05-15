using AkilliKomponentStokAsistani.Web.Models;

namespace AkilliKomponentStokAsistani.Web.Repositories
{
    public interface IComponentRepository
    {
        Task<List<ComponentItem>> GetAllAsync();
        Task<ComponentItem?> GetByIdAsync(int id);
        Task<List<ComponentItem>> GetCriticalStockItemsAsync();
        Task AddAsync(ComponentItem componentItem);
        Task UpdateAsync(ComponentItem componentItem);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}