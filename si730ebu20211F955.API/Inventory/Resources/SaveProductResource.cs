using System.ComponentModel.DataAnnotations;
using si730ebu20211F955.API.Inventory.Domain.Models.ValueObjects;

namespace si730ebu20211F955.API.Inventory.Resources;

public class SaveProductResource
{

    [Required]
    public string Brand { get; set; }
    [Required]
    public string Model { get; set; }
    [Required]
    public string StatusDescription { get; set; }
    [Required]
    public string SerialNumber { get; set; }
}

