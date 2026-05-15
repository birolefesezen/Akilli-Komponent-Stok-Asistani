using AkilliKomponentStokAsistani.Web.Models;
using AkilliKomponentStokAsistani.Web.Repositories;

namespace AkilliKomponentStokAsistani.Web.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IComponentRepository _repository;

        public ComponentService(IComponentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ComponentItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ComponentItem?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<ComponentItem>> GetCriticalStockItemsAsync()
        {
            return await _repository.GetCriticalStockItemsAsync();
        }

        public async Task AddAsync(ComponentItem componentItem)
        {
            ValidateComponentItem(componentItem);
            if (string.IsNullOrWhiteSpace(componentItem.PackageType))
            {
                componentItem.PackageType = "Unknown";
            }
            componentItem.CreatedAt = componentItem.CreatedAt == default ? DateTime.UtcNow : componentItem.CreatedAt;
            await _repository.AddAsync(componentItem);
        }

        public async Task UpdateAsync(ComponentItem componentItem)
        {
            ValidateComponentItem(componentItem);
            componentItem.UpdatedAt = DateTime.UtcNow;
            await _repository.UpdateAsync(componentItem);
        }

        public async Task DeleteAsync(int id)
        {
            if (await _repository.ExistsAsync(id))
            {
                await _repository.DeleteAsync(id);
            }
        }

        private void ValidateComponentItem(ComponentItem componentItem)
        {
            if (string.IsNullOrWhiteSpace(componentItem.ComponentName))
            {
                throw new ArgumentException("ComponentName cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(componentItem.Category))
            {
                throw new ArgumentException("Category cannot be empty.");
            }

            if (componentItem.Price < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }

            if (componentItem.StockQuantity < 0)
            {
                throw new ArgumentException("StockQuantity cannot be negative.");
            }

            if (componentItem.MinimumStockLevel < 0)
            {
                throw new ArgumentException("MinimumStockLevel cannot be negative.");
            }
        }
    }
}