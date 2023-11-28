using si730ebu20211F955.API.Inventory.Domain.Models.Aggregates;
using si730ebu20211F955.API.Inventory.Domain.Models.ValueObjects;
using si730ebu20211F955.API.Inventory.Domain.Repositories;
using si730ebu20211F955.API.Inventory.Domain.Services;
using si730ebu20211F955.API.Inventory.Domain.Services.Communication;

namespace si730ebu20211F955.API.Inventory.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ProductResponse> AddProductAsync(Product product)
    {
        var existingProduct = await _productRepository.FindBySerialNumberAsync(product.SerialNumber);
        
        if (existingProduct != null)
        {
            return new ProductResponse($"There is already a product with the same serial number, its id is: {existingProduct.Id}");
        }

        try
        {
            switch (product.StatusDescription)
            {
                case "OPERATIONAL":
                    product.Status = 1;
                    break;
                case "UNOPERATIONAL":
                    product.Status = 2;
                    break;
                default:
                    return new ProductResponse("Invalid StatusDescription, just write OPERATIONAL or UNOPERATIONAL");
            }
            await _productRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return new ProductResponse(product);
        }
        catch (Exception e)
        {
            return new ProductResponse($"An error occurred while saving the product: {e.Message}");
        }
    }

    public async Task<ProductResponse> GetProductByIdAsync(int id)
    {
        var existingProduct = await _productRepository.FindByIdAsync(id);
        
        if (existingProduct == null)
        {
            return new ProductResponse("The product doesn't exist");
        }
        
        existingProduct.updateStatusDescription();

        try
        {
            return new ProductResponse(existingProduct);
        }
        catch (Exception e)
        {
            return new ProductResponse($"An error occurred while retrieving the product: {e.Message}");
        }
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
        var products = await _productRepository.ListAsync();

        foreach (var product in products)
        {
           product.updateStatusDescription();
        }
        
        return await _productRepository.ListAsync();
    }
}