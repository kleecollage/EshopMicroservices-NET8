using Microsoft.AspNetCore.RateLimiting;

// Add services to the container
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 5;
    });
});

// Configure the HTTP request pipeline.
var app = builder.Build();

app.UseRateLimiter();

app.MapReverseProxy();

app.Run();