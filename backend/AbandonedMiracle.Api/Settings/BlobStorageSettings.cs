namespace AbandonedMiracle.Api.Settings;

public class BlobStorageSettings
{
    public const string Section = "BlobStorage";
    public string ConnectionString { get; set; }
    public string ContainerName { get; set; }
}