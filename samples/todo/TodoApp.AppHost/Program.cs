var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
    .AddPostgres("postgres")
    .WithDataVolume();

var martendb = postgres
    .AddDatabase("martendb", "postgres");

var webapi = builder
    .AddProject<Projects.TodoApp_WebApi_App>("todoapp-webapi-app")
    .WithReference(martendb);

builder
    .AddProject<Projects.TodoApp_AdminApp>("todoapp-adminapp")
    .WithReference(webapi);

builder.Build().Run();
