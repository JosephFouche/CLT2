using Core.DTOs;
using Core.Interfaces.Repositories;
using FluentValidation;
using Infrastructure;
using Infrastructure.Repositories;

using WebApi.Middlewares;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Registrar FluentValidation
// Registrar validadores
builder.Services.AddValidations();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Registra el repositorio IAccountRepository para que se pueda inyectar en los controladores
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddInfrastructure(builder.Configuration);
//builder.Services.AddRepositories();
//builder.Services.AddDatabase(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//usar middleware
//app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
