using AbandonedMiracle.Api.Settings;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace AbandonedMiracle.Api.Services;

public class ImageService : IImageService
{
    private readonly BlobStorageSettings _blobStorageSettings;
    public ImageService(IOptions<BlobStorageSettings> blobStorageSettings)
    {
        _blobStorageSettings = blobStorageSettings.Value;
    }

    public async Task<string> UploadImageAsync(string base64Image)
    {
        var imageBytes = Convert.FromBase64String(base64Image.Trim());
        var image = Image.Load<Rgba32>(imageBytes);
        image.Mutate(x => x.Resize(500, 500));
        var imageName = GenerateRandomName();
        
        var blobServiceClient = new BlobServiceClient(_blobStorageSettings.ConnectionString);
        
        var containerClient = blobServiceClient.GetBlobContainerClient(_blobStorageSettings.ContainerName);
        
        var blobClient = containerClient.GetBlobClient(imageName);
        using var stream = new MemoryStream();
        await image.SaveAsPngAsync(stream);
        stream.Position = 0;
        await blobClient.UploadAsync(stream);
        return blobClient.Uri.ToString();
    }
    
    private string GenerateRandomName()
    {
        var random = new Random();
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var result = new string(Enumerable.Repeat(chars, 30)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        return result + ".png";
    }
}