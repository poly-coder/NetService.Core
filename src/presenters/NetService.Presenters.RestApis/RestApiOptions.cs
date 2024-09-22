namespace NetService.Presenters.RestApis;

public sealed class RestApiOptions
{
    public const string SectionName = "RestApi";

    public bool Enabled { get; set; } = false;
}
