using AbandonedMiracle.Api.Entities.Identity;

namespace AbandonedMiracle.Api.Entities.Reports;

public class Report : Entity
{
    public AmUser ReportingUser { get; set; } = default!;
    public Guid ReportingUserId { get; set; }
    public DateTime ReportDate { get; set; }
    public string Description { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Longitude { get; set; } = default!;
    public string Latitude { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public ReportAnimalType AnimalType { get; set; }
    public ReportProcessingStatus ProcessingStatus { get; set; }
}