using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace TodoApp.Presenters.RestApis;

public static class Telemetry
{
    public static readonly ActivitySource ActivitySource = new("TodoApp.Presenters.RestApis", "0.1");

    public static readonly Meter Meter = new("TodoApp.Presenters.RestApis", "0.1");
}
