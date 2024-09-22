var builder = DistributedApplication.CreateBuilder(args);

var webapi = builder
    .AddProject<Projects.TodoApp_WebApi_App>("todoapp-webapi-app");

builder
    .AddProject<Projects.TodoApp_AdminApp>("todoapp-adminapp")
    .WithReference(webapi);

builder.Build().Run();
