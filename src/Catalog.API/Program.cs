var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
// SERVICES
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    // opts.AutoCreateSchemaObjects()
}).UseLightweightSessions();

// Get more readable errors with JSON format 
builder.Services.AddExceptionHandler<CustomExceptionHandler>();


var app = builder.Build();
// HTTP request pipeline
app.MapCarter();

// Get more readable errors with JSON format 
app.UseExceptionHandler(options => { });

app.Run();