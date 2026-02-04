var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
// ====================   SERVICES   ==================== //
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    // opts.AutoCreateSchemaObjects()
}).UseLightweightSessions();

// Data seed
if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();

// Get more readable errors with JSON format 
builder.Services.AddExceptionHandler<CustomExceptionHandler>();


// ====================   HTTP request pipeline   ==================== //
var app = builder.Build();
app.MapCarter();

// Get more readable errors with JSON format 
app.UseExceptionHandler(options => { });

app.Run();