using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

// ==============================   Add services to the container   ============================== //
var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

// FluentValidation
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);
    // opts.AutoCreateSchemaObjects;
}).UseLightweightSessions();

// Scopes
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

// builder.Services.AddScoped<IBasketRepository>(provider =>
// {
//     var basketRepository = provider.GetRequiredService<BasketRepository>();
//     return new CachedBasketRepository(basketRepository, provider.GetRequiredService<IDistributedCache>());
// });

// Using Scrutor
builder.Services.Decorate<IBasketRepository, CachedBasketRepository>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "Basket";
});

// Get more readable errors with JSON format 
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

// Health check
builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("Database")!)
    .AddRedis(builder.Configuration.GetConnectionString("Redis")!);

// ==============================   Configure the HTTP request pipeline   ============================== //
var app = builder.Build();

app.MapCarter();

// Get more readable errors with JSON format 
app.UseExceptionHandler(options => { });

// Health check
app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.Run();