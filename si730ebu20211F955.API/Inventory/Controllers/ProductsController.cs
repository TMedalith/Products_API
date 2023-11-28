using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using si730ebu20211F955.API.Academy.Resources;
using si730ebu20211F955.API.Inventory.Domain.Models.Aggregates;
using si730ebu20211F955.API.Inventory.Domain.Services;
using si730ebu20211F955.API.Inventory.Resources;
using si730ebu20211F955.API.Shared.Extensions;

namespace si730ebu20211F955.API.Inventory.Controllers;

/**
 * Categories Controller
 * <summary>
 *     This controller is responsible for handling all the requests related to categories.
 * </summary>
 */
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Product Management")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;


    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    /**
     * Create Category
     * <summary>
     *     This method is responsible for handling the request to create a category.
     * </summary>
     * <param name="createCategoryResource">The create category resource.</param>
     * <returns>The category resource.</returns>
     */
    [HttpPost]
    [ProducesResponseType(typeof(ProductResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody]SaveProductResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var product = _mapper.Map<SaveProductResource, Product>(resource);

        var result = await _productService.AddProductAsync(product);

        if (!result.Success)
            return BadRequest(result.Message);

        var productResource = _mapper.Map<Product, ProductResource>(result.Resource);

        return Ok( productResource);
    }
    
    [HttpGet]
    public async Task<IEnumerable<ProductResource>> GetAllAsync()
    {
        var products = await _productService.ListAsync();
        
        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);

        var productResource = _mapper.Map<Product, ProductResource>(product.Resource);

        return Created(nameof(GetProductById), productResource);
    }

}