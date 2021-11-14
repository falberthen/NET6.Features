using System;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using NET6.Features.Models.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
	s.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "Planetary API",
		Description = "Planetary API Swagger",
		Contact = new OpenApiContact { Name = "Felipe Alberto", Email = "fealberto@gmail.com" },
		License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://github.com/falberthen/NET6.Features/blob/master/LICENSE.txt") }
	});

});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Planetary API V1");
});

app.MapGet("/", () => SpaceService.GetPlanetsOfSolarSystem());
app.MapGet("/gasgiantplanets", () => SpaceService.GetGasGiantPlanets());
app.Run();