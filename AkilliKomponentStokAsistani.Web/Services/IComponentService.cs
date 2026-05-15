using AkilliKomponentStokAsistani.Web.Models;

namespace AkilliKomponentStokAsistani.Web.Services
{
    public interface IComponentService
    {
        Task<List<ComponentItem>> GetAllAsync();
        Task<ComponentItem?> GetByIdAsync(int id);
        Task<List<ComponentItem>> GetCriticalStockItemsAsync();
        Task AddAsync(ComponentItem componentItem);
        Task UpdateAsync(ComponentItem componentItem);
        Task DeleteAsync(int id);
    }
}