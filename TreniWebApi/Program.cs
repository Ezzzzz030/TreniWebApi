using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TreniDataModel.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<TreniDbContext>(x => x.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:Connection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
