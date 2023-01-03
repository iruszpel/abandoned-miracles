namespace AbandonedMiracle.Api.Services;

public interface IImageService
{
    Task<string> UploadImageAsync(string base64Image);
}