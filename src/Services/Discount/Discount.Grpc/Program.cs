// ==============================   Add services to the container.   ============================== //
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();



// ==============================   Configure the HTTP request pipeline.   ============================== //
var app = builder.Build();

app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();