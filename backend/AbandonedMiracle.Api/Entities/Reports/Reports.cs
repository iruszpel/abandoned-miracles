using AbandonedMiracle.Api.Entities.Identity;

namespace AbandonedMiracle.Api.Entities.Reports;

public class Report : Entity
{
    public AmUser RegisteringUser { get; set; } = default!;
    public Guid RegisteringUserId { get; set; }
    public DateTime ReportDate { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Address { get; set; } = default!;
    public Guid? ImageId { get; set; }
    public ReportAnimalType AnimalType { get; set; }
    public ReportProcessingStatus ProcessingStatus { get; set; }
}