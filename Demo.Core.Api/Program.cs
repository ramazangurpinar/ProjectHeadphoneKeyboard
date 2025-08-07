using Demo.Core.Api.Middlewares;
using Demo.Core.Application.Interfaces;
using Demo.Core.Application.Validators;
using Demo.Core.Infrastructure.Persistence;
using Demo.Core.Infrastructure.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the HeadphoneService
builder.Services.AddScoped<IHeadphoneService, HeadphoneService>();
// Register the KeyboardService
builder.Services.AddScoped<IKeyboardService, KeyboardService>();
builder.Services.AddValidatorsFromAssemblyContaining<HeadphoneCreateDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<KeyboardCreateDtoValidator>();
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();
app.Run();
