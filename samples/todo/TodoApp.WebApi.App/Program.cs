using FluentValidation;
using Marten;
using Oakton;
using Oakton.Resources;
using Weasel.Core;
using Wolverine;
using Wolverine.FluentValidation;
using Wolverine.Marten;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.AddRestApis(new AddRestApisOptions
{
    Parts = [TodoAppPresentersRestApis.Assembly],
});

builder.Services.AddRazorPages();

builder.Services.AddValidatorsFromAssemblies([
    TodoAppApplicationModels.Assembly
]);

builder.Host.ApplyOaktonExtensions();

builder.Services
    .AddMarten(options =>
    {
        var connectionString =
            builder.Configuration.GetConnectionString("martendb")
            ?? throw new InvalidOperationException("Connection string 'martendb' is missing");

        options.Connection(connectionString);

        options.UseSystemTextJsonForSerialization();

        options.AutoCreateSchemaObjects = builder.Environment.IsDevelopment()
            ? AutoCreate.All
            : AutoCreate.None;

        options.DatabaseSchemaName = "todoapp";
    })
    .UseLightweightSessions()
    .OptimizeArtifactWorkflow()
    .ApplyAllDatabaseChangesOnStartup()
    .IntegrateWithWolverine("wolverine");

builder.Host.UseWolverine(options =>
{
    options.UseFluentValidation(RegistrationBehavior.ExplicitRegistration);

    options.Discovery.IncludeAssembly(TodoAppApplication.Assembly);

    // Troubleshooting Handler Discovery 
    // https://wolverinefx.net/guide/handlers/discovery#troubleshooting-handler-discovery
    // Console.WriteLine(options.DescribeHandlerMatch(typeof(GetTodoDetailsQueryHandler)));
});

builder.Services.AddResourceSetupOnStartup();


var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRestApis();

app.MapRazorPages();

await app.RunOaktonCommands(args);
