using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using AbandonedMiracle.Api.DataAccess;
using AbandonedMiracle.Api.Dtos.Classification;
using AbandonedMiracle.Api.Entities.Reports;
using Newtonsoft.Json;

namespace AbandonedMiracle.Api.Tasks;

public class ClassifyPhotosTask : IHostedService, IDisposable
{
    private readonly ILogger<ClassifyPhotosTask> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private Timer? _timer = null;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ClassifyPhotosTask(ILogger<ClassifyPhotosTask> logger, IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
        _jsonSerializerOptions = new JsonSerializerOptions()
        {
            Converters = { new JsonStringEnumConverter() },
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service running.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(5));

        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        try
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AmDbContext>();
            var photos = context.Reports.Where(p => p.Processed == false).ToList();
            foreach (var photo in photos)
            {
                ClassifyPhoto(photo).Wait();
            }

            context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in ClassifyPhotosTask");
        }
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }

    private async Task ClassifyPhoto(Report report)
    {
        _logger.LogInformation("Classifying photo {0}", report.Id);
        var client = new HttpClient();
        var response =
            await client.PostAsync("https://hycelanimalclassification.azurewebsites.net/api/GetAnimalClassification",
                new StringContent(JsonConvert.SerializeObject(new {imageUrl = report.ImageUrl}), Encoding.UTF8, "application/json"));
        if(response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<ClassificationResult>(_jsonSerializerOptions);
            if(content != null)
            {
                var bestRecord = content.Result.Predictions.OrderByDescending(x => x.Probability).First();
                if(bestRecord.Probability > 0.5)
                {
                    report.AnimalType = bestRecord.Animal;
                }
            }
        }
        report.Processed = true;
    }
}