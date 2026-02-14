using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extensions;

// ==============================   Add services to the container   ============================== //
// ------------------------------
// Infrastructure - EF Core
// Application - MediatR
// API - Carter, HealthChecks, ...
// ------------------------------
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);



// ==============================   Configure HTTP request pipeline   ============================== //
var app = builder.Build();

app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();

