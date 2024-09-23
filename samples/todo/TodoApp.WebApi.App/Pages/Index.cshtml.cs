using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using NetService.Presenters.RestApis;

namespace TodoApp.WebApi.App.Pages;

public class IndexModel() : PageModel
{
    public IEnumerable<EndpointModel> Endpoints { get; set; } = [];

    public void OnGet()
    {
        Endpoints =
        [
            new EndpointModel
            {
                Enabled = true,
                Label = "REST APIs",
                Urls =
                [
                    new EndpointUrlModel("Open API Documentation", "/swagger"),
                    new EndpointUrlModel("Open API JSON", "/swagger/v1/swagger.json")
                ]
            },
            //new EndpointModel
            //{
            //    Enabled = false,
            //    Label = "gRPC APIs",
            //    Urls =
            //    [
            //        new EndpointUrlModel("gRPC Reflection", "/grpc/reflection")
            //    ]
            //},
            //new EndpointModel
            //{
            //    Enabled = false,
            //    Label = "Messaging APIs",
            //    Urls =
            //    [
            //        new EndpointUrlModel("RabbitMQ Management", "/rabbitmq")
            //    ]
            //},
            new EndpointModel
            {
                Enabled = true,
                Label = "Health Checks",
                Urls =
                [
                    new EndpointUrlModel("Health", "/health"),
                    new EndpointUrlModel("Alive", "/alive")
                ]
            }
        ];
    }
}

public class EndpointModel
{
    public required bool Enabled { get; set; }
    public required string Label { get; set; }
    public required IEnumerable<EndpointUrlModel> Urls { get; set; }
}

public record EndpointUrlModel(
    string Label,
    string Url,
    string? UrlLabel = null)
{
    public string GetUrlLabel() => UrlLabel ?? Url;
}
