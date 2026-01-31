var builder = WebApplication.CreateBuilder(args);
// SERVICES
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();
// HTTP request pipeline
app.MapCarter();

app.Run();