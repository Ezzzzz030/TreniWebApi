using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TreniDataModel.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Configuration.GetValue<string>("ConnectionStrings:Connection");
builder.Services.AddDbContext<TreniDbContext>(x => x.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:Connection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();
