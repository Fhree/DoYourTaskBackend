using DYT.api.DependencyInjection;
using DYT.infrastructure.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DoYourTaskDBContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DoYourTaskDB"), p =>
    {
        p.MigrationsAssembly("DYT.api");
    });
});

builder.Services.AddDependencyInjection();
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("DYT.businessLogic")); });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowLocalhost");

app.Run();
