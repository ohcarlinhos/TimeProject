using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using API.Database;
using API.Infrastructure.Config;
using API.Infrastructure.Mapping;

var builder = WebApplication.CreateBuilder(args);

const string customCors = "_customCors";
CorsBuilderConfig.Apply(builder, customCors);
JwtBuilderConfig.Apply(builder);

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();

SwaggerBuilderConfig.Apply(builder);
DatabaseBuilderConfig.Apply(builder);
RepositoriesBuilderConfig.Apply(builder);
ServicesBuilderConfig.Apply(builder);
IntegrationsBuilderConfig.Apply(builder);
HandlersBuilderConfig.Apply(builder);
MappingBuilderConfig.Apply(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");

    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseCors(customCors);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();