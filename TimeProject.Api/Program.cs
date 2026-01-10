using System.Text.Json.Serialization;
using TimeProject.Api.Controllers.Middlewares;
using TimeProject.Api.Infrastructure.Config;

var builder = WebApplication.CreateBuilder(args);

const string customCorsName = "_customCors";
builder.AddCorsConfig(customCorsName);

// Injeção de todos os serviços.
builder.AddServicesConfig();
builder.AddCustomAuthorizationConfig();

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