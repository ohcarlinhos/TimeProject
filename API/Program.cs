using System.Text.Json.Serialization;
using API.Infrastructure.Config;

var builder = WebApplication.CreateBuilder(args);

const string customCors = "_customCors";
CorsBuilderConfig.Apply(builder, customCors);

SettingsBuilderConfig.Apply(builder);
JwtBuilderConfig.Apply(builder);

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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