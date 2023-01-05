using AbandonedMiracle.Api.Entities.Reports;

namespace AbandonedMiracle.Api.Dtos.Reports;

public class ReportDto
{
    public Guid Id { get; set; }
    public DateTime ReportDate { get; set; }
    public string Description { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Longitude { get; set; } = default!;
    public string Latitude { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public ReportAnimalType AnimalType { get; set; }
    public ReportStatus Status { get; set; }
}