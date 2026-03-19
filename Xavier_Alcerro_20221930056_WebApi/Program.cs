using Microsoft.EntityFrameworkCore;
using Xavier_Alcerro_20221930056_WebApi.Data;
using Xavier_Alcerro_20221930056_WebApi.Repositories;
using Xavier_Alcerro_20221930056_WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<IVideojuegoRepositorio, VideojuegoRepositorio>();

// Validaciones
builder.Services.AddScoped<IValidacionCategoria, ValidacionCategoria>();
builder.Services.AddScoped<IValidacionVideojuego, ValidacionVideojuego>();

// Services
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IVideojuegoService, VideojuegoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();