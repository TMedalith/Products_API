using si730ebu20211F955.API.Inventory.Domain.Models.Aggregates;

namespace si730ebu20211F955.API.Inventory.Domain.Repositories;

public interface IProductRepository
{
    Task<Product> FindBySerialNumberAsync(string serialNumber);
    Task<Product> FindByIdAsync(int id);
    Task AddAsync(Product product);
    Task<IEnumerable<Product>> ListAsync();

}