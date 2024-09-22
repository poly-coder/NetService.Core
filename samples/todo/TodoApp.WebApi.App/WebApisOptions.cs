namespace TodoApp.WebApi.App;


public class GrpcApiOptions
{
    public const string SectionName = "GrpcApi";

    public bool Enabled { get; set; } = false;
}

public class MessagingApiOptions
{
    public const string SectionName = "MessagingApi";

    public bool Enabled { get; set; } = false;
}
