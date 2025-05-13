using ApiPersonajesAWS.Data;
using ApiPersonajesAWS.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("MySql");
builder.Services.AddDbContext<PersonajesContext>(options =>
    options.UseMySQL(connectionString));
builder.Services.AddScoped<RepositoryPersonajes>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.MapScalarApiReference(options => 
    options.BaseServerUrl = "/scalar");
app.MapOpenApi();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
