﻿using Ordering.Application;
using Ordering.Infrastructure;
using Microsoft.Extensions.Configuration;
using Ordering.Infrastructure.Persistence;
using Ordering.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MigrateDatabase<OrderContext>((context, services) =>
 {
     var logger = services.GetService<ILogger<OrderContextSeed>>();
     OrderContextSeed
         .SeedAsync(context, logger)
         .Wait();
 });
app.MapControllers();

app.Run();

