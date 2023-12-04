var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedisContainer("redis");

var api = builder.AddProject<Projects.Api>("api")
    .WithReference(redis);

builder.AddProject<Projects.Frontend>("frontend")
    .WithReference(api);

builder.Build().Run();
