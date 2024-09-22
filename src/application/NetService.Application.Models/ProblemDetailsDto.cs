namespace NetService.Application.Models;

public class ProblemDetailsDto
{
    public string? Type { get; init; }
    public string? Title { get; init; }
    public int? Status { get; init; }
    public string? Detail { get; init; }
    public string? Instance { get; init; }
    public Dictionary<string, object?>? Extensions { get; init; }
}

public class ValidationProblemDetailsDto : ProblemDetailsDto
{
    public Dictionary<string, string[]>? Errors { get; init; }
}
