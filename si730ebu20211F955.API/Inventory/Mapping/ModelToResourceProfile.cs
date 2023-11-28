using AutoMapper;
using si730ebu20211F955.API.Academy.Resources;
using si730ebu20211F955.API.Inventory.Domain.Models.Aggregates;

namespace si730ebu20211F955.API.Inventory.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Product, ProductResource>();
    }
    
}