var builder = WebApplication.CreateBuilder(args);

// SERVICES

var app = builder.Build();

// HTTP request pipeline

app.Run();