using System.ComponentModel.DataAnnotations.Schema;
using si730ebu20211F955.API.Inventory.Domain.Models.ValueObjects;

namespace si730ebu20211F955.API.Inventory.Domain.Models.Aggregates;
/**
 * Tutorial aggregate root
 * <summary>
 *     This is the aggregate root of the tutorial content. It is responsible for managing the assets and the publishing
 *     status of the tutorial.
 *     It is also responsible for the publishing workflow.
 * </summary>
 */
public class Product
{
   
    public int Id { get; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    
    
    public int Status { get; set; }
    
    [NotMapped]
    public string StatusDescription
    {
        get;
        set;
    }
    
    

    public void updateStatusDescription()
    {
        StatusDescription =  (Status == 1) ? "OPERATIONAL" :
            Status == 2 ? "UNOPERATIONAL" :
            "Unknown Status";
    }
}