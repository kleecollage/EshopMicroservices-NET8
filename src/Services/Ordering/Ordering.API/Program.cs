using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// ==============================   Add services to the container   ============================== //
var app = builder.Build();

// ------------------------------
// Infrastructure - EF Core
// Application - MediatR
// API - Carter, HealthChecks, ...
// ------------------------------

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();



// ==============================   Configure HTTP request pipeline   ============================== //
app.Run();