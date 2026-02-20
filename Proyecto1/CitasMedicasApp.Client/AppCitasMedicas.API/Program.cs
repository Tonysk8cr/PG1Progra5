using AppCitasMedicas.AccesoDatos.Models;
using AppCitasMedicas.Negocio.Implementaciones;
using AppCitasMedicas.Negocio.Interfaces;
using AppCitasMedicas.Repositorio.Implementaciones;
using AppCitasMedicas.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CitasMedicasContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("CitasMedicas")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositorios
builder.Services.AddScoped<ICitasRepositorio, CitasRepositorio>();
builder.Services.AddScoped<IDoctorRepositorio, DoctorRepositorio>();
builder.Services.AddScoped<IEspecialidadRepositorio, EspecialidadRepositorio>();
builder.Services.AddScoped<IPacientesRepositorio, PacientesRepositorio>();

// Negocio
builder.Services.AddScoped<ICitasNegocio, CitasNegocio>();
builder.Services.AddScoped<IDoctorNegocio, DoctorNegocio>();
builder.Services.AddScoped<IEspecialidadNegocio, EspecialidadNegocio>();
builder.Services.AddScoped<IPacientesNegocio, PacientesNegocio>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();