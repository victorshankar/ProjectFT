using Microsoft.EntityFrameworkCore;
using ProjectFT.Data;
using ProjectFT.Interfaces;
using ProjectFT.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApiDbContext>(option =>option.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjectFTDB;Integrated Security=True;"));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
