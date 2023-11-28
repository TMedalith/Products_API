using si730ebu20211F955.API.Inventory.Domain.Models.Aggregates;
using si730ebu20211F955.API.Shared.Domain.Services.Communication;

namespace si730ebu20211F955.API.Inventory.Domain.Services.Communication;

public class ProductResponse : BaseResponse<Product>
{
    public ProductResponse(string message) : base(message)
    {
    }

    public ProductResponse(Product resource) : base(resource)
    {
    }
}