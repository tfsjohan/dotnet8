var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedisContainer("redis");

var api = builder.AddProject<Projects.Api>("api")
    .WithReference(redis);

builder.AddProject<Projects.Frontend>("frontend")
    .WithReference(api);

builder.AddProject<Projects.Frontend_Client>("frontend_client");
    

builder.Build().Run();
