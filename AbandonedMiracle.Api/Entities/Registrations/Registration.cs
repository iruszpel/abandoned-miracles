using AbandonedMiracle.Api.Entities.Identity;

namespace AbandonedMiracle.Api.Entities.Registrations;

public class Registration : Entity
{
    public AmUser RegisteringUser { get; set; } = default!;
    public Guid RegisteringUserId { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Address { get; set; } = default!;
    public Guid? ImageId { get; set; }
    public RegistrationAnimalType AnimalType { get; set; }
    public RegistrationProcessingStatus ProcessingStatus { get; set; }
}