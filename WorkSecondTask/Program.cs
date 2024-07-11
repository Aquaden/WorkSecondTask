using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Application.CQRS.Handlers.CommandHandlers;
using Project.Application.CQRS.Handlers.QueryHandlers;
using Project.Application.Profiles;
using Project.SQL.Server.DbContexts;
using Project.SQL.Server;
using Project.Application.EXtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conf = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(conf));
builder.Services.AddSqlServerServices(conf);
builder.Services.AddMainExtension(builder.Configuration);
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
