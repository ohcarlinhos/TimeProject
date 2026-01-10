using System.Text.Json.Serialization;
using TimeProject.Api.Configurations;
using TimeProject.Api.Controllers.Middlewares;

var builder = WebApplication.CreateBuilder(args);

const string customCorsName = "_customCors";
builder.AddCorsConfiguration(customCorsName);

// Injeção de todos os serviços.
builder.AddServicesConfig();
builder.AddCustomAuthorizationConfiguration();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();

builder.AddSwaggerConfig();
builder.AddDatabaseConfig();

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

app.UseCors(customCorsName);
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseMiddleware<UserChallengeMiddleware>();
app.MapControllers();

app.Run();