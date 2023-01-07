using AbandonedMiracle.Api.Entities.Reports;

namespace AbandonedMiracle.Api.Dtos.Classification;

public class ClassificationResult
{
    public Result Result { get; set; }
}

public class Result
{
    public List<Prediction> Predictions { get; set; }
}

public class Prediction
{
    public ReportAnimalType Animal { get; set; }
    public double Probability { get; set; }
}