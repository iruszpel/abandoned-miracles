namespace AbandonedMiracle.Api.Dtos.Reports;

public class PagedReportDto
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public IEnumerable<ReportDto> Items { get; set; }
}