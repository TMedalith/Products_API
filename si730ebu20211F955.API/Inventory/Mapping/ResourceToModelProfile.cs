using AutoMapper;
using si730ebu20211F955.API.Academy.Resources;
using si730ebu20211F955.API.Inventory.Domain.Models.Aggregates;
using si730ebu20211F955.API.Inventory.Resources;

namespace si730ebu20211F955.API.Inventory.Mapping;


public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveProductResource, Product>();
    }
}