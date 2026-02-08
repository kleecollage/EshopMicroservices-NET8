using Discount.Grpc.Data;
using Discount.Grpc.Services;
using Microsoft.EntityFrameworkCore;

// ==============================   Add services to the container.   ============================== //
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

// SQLite DB
builder.Services.AddDbContext<DiscountContext>(opts =>
{
    opts.UseSqlite(builder.Configuration.GetConnectionString("Database"));
});


// ==============================   Configure the HTTP request pipeline.   ============================== //
var app = builder.Build();

app.UseMigration();
    
app.MapGrpcService<DiscountService>();

app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();