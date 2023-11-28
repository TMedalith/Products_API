using Microsoft.EntityFrameworkCore;
using si730ebu20211F955.API.Inventory.Domain.Models.Aggregates;
using si730ebu20211F955.API.Inventory.Domain.Repositories;
using si730ebu20211F955.API.Shared.Persistence.Contexts;
using si730ebu20211F955.API.Shared.Persistence.Repositories;

namespace si730ebu20211F955.API.Inventory.Persistence.Repositories;
/**
 * Tutorial Repository
 * <summary>
 *     This class is used to handle the CRUD operations for the Tutorial entity
 * </summary>
 */
public class ProductRepository: BaseRepository, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
    
    /**
  * Find Tutorial By Id
  * <summary>
  *     This method is used to find a tutorial by id, overriding the base method to include the category
  * </summary>
  * @param int id
  */
    
    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> FindBySerialNumberAsync(string serialNumber)
    {
        return await _context.Products.FirstOrDefaultAsync(product => product.SerialNumber == serialNumber);
    }

    public async Task<Product> FindByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task AddAsync(Product product)
    {
         await _context.Products.AddAsync(product);
    }
}