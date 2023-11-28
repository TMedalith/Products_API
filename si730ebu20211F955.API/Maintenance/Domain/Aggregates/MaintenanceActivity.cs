namespace si730ebu20211F955.API.Maintenance.Domain.Aggregates;

public class MaintenanceActivity
{
    public MaintenanceActivity(string productSerialNumber, string summary, string description, int activityResult)
    {
        ProductSerialNumber = productSerialNumber;
        Summary = summary;
        Description = description;
        ActivityResult = activityResult;
    }

    public int Id { get; set; }
    public string ProductSerialNumber { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public int ActivityResult { get; set; }
}