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



// ==============================   Configure the HTTP request pipeline   ============================== //
var app = builder.Build();

app.MapCarter();

app.Run();