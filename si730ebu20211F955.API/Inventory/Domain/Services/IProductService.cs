using si730ebu20211F955.API.Inventory.Domain.Models.Aggregates;
using si730ebu20211F955.API.Inventory.Domain.Services.Communication;

namespace si730ebu20211F955.API.Inventory.Domain.Services;

public interface IProductService
{
    Task<ProductResponse> AddProductAsync(Product product);
    Task<ProductResponse> GetProductByIdAsync(int id);
    Task<IEnumerable<Product>> ListAsync();

}