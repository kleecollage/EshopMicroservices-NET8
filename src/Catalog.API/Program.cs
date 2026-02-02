var builder = WebApplication.CreateBuilder(args);
// SERVICES
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    // opts.AutoCreateSchemaObjects()
}).UseLightweightSessions();

var app = builder.Build();
// HTTP request pipeline
app.MapCarter();

app.Run();