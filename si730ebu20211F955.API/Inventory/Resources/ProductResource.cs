using System.Reflection;
using si730ebu20211F955.API.Inventory.Domain.Models.ValueObjects;

namespace si730ebu20211F955.API.Academy.Resources;

/// <summary>
/// Represents a resource for products.
/// </summary>
/// <remarks>
/// Created by Tatiana Paucar
/// </remarks>
public class ProductResource
{
    /// <summary>
    /// These attributes include
    /// the response that will be shown to the user
    /// if the object has been correctly saved.
    /// The isDefault attribute is not included
    /// here by request of the statement
    /// </summary>
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Status { get; set; }
    public string SerialNumber { get; set; }
    public string StatusDescription { get; set; }
}